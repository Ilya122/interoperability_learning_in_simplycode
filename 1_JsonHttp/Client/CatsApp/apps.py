import cherrypy
import pyvibe as pv

# cherrypy - עוזר לנו להריץ את האתר
# pyvie - Html Builder

# אפליקציית החתולים
class CatsApp(object):
    def __init__(self):
        # קובעים כמה משתנים בסיסיים כדי לדעת מאיפה לקחת את התמונות ומה החתול הנוכחי
        self.baseUrl = "https://localhost:7264/cats"
        self.currentCat = 1
        super().__init__()

    # הכתובת הראשית שלנו, אין לנו יותר מדי לוגיקה
    @cherrypy.expose
    def index(self, catNum=1):
        catNum = int(catNum)
        self.currentCat = catNum

        # משתמשים ב- Pyvibe
        # כדי ליצור את העמוד שלנו
        page = pv.Page('Cats world', navbar=pv.Navbar(
            'Cats World', logo=''), footer=pv.Footer(), additional_head='')

        # נכניס הכל לקונטיינר
        with page.add_container() as container:
            
            # משתמשים בטריק של כפתור לעבור בין כתובות רלטיביים ולא אבסולוטים
            # באופן הזה נוכל להעביר את החתול הנוכחי ולעשות כאילו יש לנו עמודים
            container.add_header(f'Cat num {self.currentCat}')
            if(catNum > 1):
                prevCat = catNum-1
                container.add_html(
                    f'<button onclick="window.location.href=\'/?catNum={prevCat}\'\" >Previous</button>')
            # את החתול אנחנו לוקחים ישירות מהשרת
            container.add_image(url=self.getCatUrl(
                self.currentCat), alt='cat pic')
            nextCat = catNum+1
            container.add_html(
                f'<button onclick="window.location.href=\'/?catNum={nextCat}\'\" >Next</button>')

        return page.to_html()

    def getCatUrl(self, catNum: int):
        urlToGet = self.baseUrl+f"/{catNum}"
        return urlToGet


if __name__ == '__main__':
    cherrypy.quickstart(CatsApp())
