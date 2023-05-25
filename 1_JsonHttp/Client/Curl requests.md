#Accessing api

```
curl -X GET https://localhost:7264/
```

#Getting number of cats

```
curl -X GET https://localhost:7264/cats
```

#Getting a specific cat

```
curl -X GET https://localhost:7264/cats/1
```

#Uploading an image to the cats api

```
curl -v -k -H "image/jpeg" -F file=@newCat.jpg https://localhost:7264/cats
```

Notes:
- Change port if you run on another port.
- If you change IP change it as well.