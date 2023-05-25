using System.Text.RegularExpressions;
using System.Linq;
using System.IO;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace MainServer
{
    public record Cat(string Number, string FileName);

    public record CatStats(int Amount, IEnumerable<string> Files);

    public class Cats
    {
        private string mDirectory = "cats";
        private List<Cat> mCatFiles;

        private Cats(IEnumerable<string> cats, string dir)
        {
            mDirectory = dir;
            Regex nameReg = new("cat_([0-9]+)\\..*");

            var currDirr = Directory.GetCurrentDirectory();
            mCatFiles = cats.Select(file =>
            {

                var fullPath = Path.Combine(currDirr, file);
                var match = nameReg.Match(file);
                var number = match.Groups[1];
                return new Cat(number.Value, fullPath);
            }).ToList();
        }

        public static Cats Create(string currentDir = "")
        {
            var catList = Directory.GetFiles(currentDir, "cat_*");
            return new Cats(catList, currentDir);
        }

        public void StoreCat(IFormFile file)
        {
            var lastCat = AllCats.Last();
            if (lastCat == null)
            {
                return;
            }

            var catNum = int.Parse(lastCat.Number);
            ++catNum;

            var newNum = catNum.ToString();
            var newPath = Path.Combine(mDirectory, $"cat_{catNum}.jpg");

            using var stream = File.OpenWrite(newPath);
            file.CopyTo(stream);
            mCatFiles.Add(new Cat(newNum, newPath));
        }

        public string GetStats()
        {
            CatStats stats = new CatStats(AllCats.Count, AllCats.Select(cat => Path.GetFileName(cat.FileName)));

            return JsonSerializer.Serialize(stats);
        }

        public IReadOnlyList<Cat> AllCats { get => mCatFiles; }


    }
}