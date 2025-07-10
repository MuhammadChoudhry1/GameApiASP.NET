# Game Store API

Hey there! Welcome to my Game Store API project. I built this because I love games and wanted to create a simple way to manage game collections. It's a RESTful API that lets you store, retrieve, update, and delete games - all the good stuff you'd expect from a proper API!

The best part? Everything is stored in a simple JSON file, so you don't need to mess around with databases. Just run it and start managing your games right away!

## What Can You Do With This?

Here's what I've cooked up for you:

- **GET** `/api/games` - Want to see all your games? This is your go-to endpoint
- **GET** `/api/games/{id}` - Looking for a specific game? Just pass the ID and boom!
- **POST** `/api/games` - Got a new game to add? This will take care of it
- **PUT** `/api/games/{id}` - Need to update game info? No problem!
- **DELETE** `/api/games/{id}` - Time to say goodbye to a game? This will do it
- **GET** `/health` - Just want to check if everything's running smoothly? Here you go

## What's Under the Hood?

I kept things simple but modern:

- **Framework**: ASP.NET Core 9.0 (because why not use the latest and greatest?)
- **Language**: C# (my favorite!)
- **Data Storage**: Just a JSON file (no database headaches)
- **Documentation**: Swagger/OpenAPI (so you can play around with the API easily)
- **Frontend**: A nice HTML/CSS/JavaScript test interface (because who doesn't love a good UI?)

## What Does a Game Look Like?

Here's the structure I'm using for games. Pretty straightforward, right?

```json
{
  "id": 1,
  "name": "Game Name",
  "genre": "Action-Adventure",
  "platform": "PC",
  "price": 59.99,
  "developer": "Developer Name",
  "publisher": "Publisher Name",
  "releaseDate": "2023-01-01T00:00:00Z",
  "description": "Game description",
  "rating": 9.5
}
```

## 🏃‍♂️ Getting Started (It's Super Easy!)

Don't worry, I made this as simple as possible:

1. **First things first**: Make sure you have .NET 9.0 SDK installed (if you don't, grab it from Microsoft's website)
2. **Jump into the project**:
   ```bash
   cd gamestore.api
   ```
3. **Get the packages**:
   ```bash
   dotnet restore
   ```
4. **Fire it up**:
   ```bash
   dotnet run
   ```
5. **Start playing**:
   - Test Interface: `http://localhost:5088` (this is where the magic happens!)
   - Swagger Documentation: `http://localhost:5088/swagger` (for the technical folks)
   - Health Check: `http://localhost:5088/health` (just to make sure everything's good)

## 🌐 Playing with the API

Alright, let's talk about how you can actually use this thing! I've made it super straightforward:

### Want to see all your games?
```http
GET /api/games
```
Just hit this endpoint and you'll get everything in your collection. Easy peasy!

### Looking for a specific game?
```http
GET /api/games/{id}
```
Replace `{id}` with the game's ID number. Like `/api/games/1` for the first game.

### Adding a new game to your collection?
```http
POST /api/games
Content-Type: application/json

{
  "name": "New Game",
  "genre": "RPG",
  "platform": "PC",
  "price": 49.99,
  "developer": "Developer",
  "publisher": "Publisher",
  "releaseDate": "2023-12-01T00:00:00Z",
  "description": "A new game description",
  "rating": 8.5
}
```
Send this JSON and boom - new game added! The API will automatically assign it an ID.

### Need to update something?
```http
PUT /api/games/{id}
Content-Type: application/json

{
  "name": "Updated Game",
  "genre": "RPG",
  "platform": "PC",
  "price": 39.99,
  "developer": "Developer",
  "publisher": "Publisher",
  "releaseDate": "2023-12-01T00:00:00Z",
  "description": "Updated description",
  "rating": 9.0
}
```
Just send the updated info to the specific game's ID. All fields will be updated with what you send.

### Time to remove a game?
```http
DELETE /api/games/{id}
```
Sometimes you gotta let go. This will permanently remove the game from your collection.

## How I Organized Everything

I kept the project structure clean and simple. Here's what you'll find:

```
gamestore.api/
├── Controllers/
│   └── GamesController.cs      # This is where all the API magic happens
├── Models/
│   └── Game.cs                 # The blueprint for what a game looks like
├── Services/
│   └── GameService.cs          # The brain - handles all the file operations
├── wwwroot/
│   └── index.html             # Your friendly test interface
├── Program.cs                  # Where I set everything up
├── games.json                  # Your actual game data lives here
└── gamestore.api.csproj       # Project configuration
```

## 🔧 Configuration Stuff

Don't worry, there's barely any configuration needed! Just this simple setting:

```json
{
  "GameDataFile": "games.json"
}
```

Want to change where your games are stored? Just update that file path. Easy!

## Testing It Out

I've made testing super fun and easy:

- **Interactive Web Interface**: Forget Postman! I built you a beautiful web interface where you can test everything with just clicks and form fills
- **Swagger UI**: For the developers who like their documentation interactive and comprehensive
- **Sample Data**: I've pre-loaded 5 awesome games so you can start playing around immediately

## Sample Games I Included

I couldn't resist adding some of my favorite games to get you started:

- **The Legend of Zelda: Breath of the Wild** - Because who doesn't love Link?
- **Red Dead Redemption 2** - Cowboys and horses, need I say more?
- **Cyberpunk 2077** - Futuristic chaos at its finest
- **God of War** - Kratos and Atreus on their epic journey
- **Minecraft** - The game that never gets old

## How Your Data Gets Saved

Here's the cool part - everything you do gets saved instantly to the `games.json` file. Add a game? It's saved. Update something? Boom, saved. Delete a game? Gone and saved. 

The file gets created automatically if it doesn't exist, so you don't need to worry about setup. Just start using it!

## What If Things Go Wrong?

I've got you covered! The API handles errors gracefully:

- **404 Not Found**: Looking for a game that doesn't exist? You'll get a nice message telling you so
- **400 Bad Request**: Forgot to fill out a required field? The API will let you know what's missing
- **500 Internal Server Error**: Something went really wrong? Don't worry, it's not your fault!

## Cool Features I Built In

Here are some neat things that make this API special:

- **Auto-incrementing IDs**: You don't need to worry about IDs - I handle that automatically
- **Data validation**: The API makes sure you're sending the right stuff
- **CORS enabled**: Want to use this from a web app? No problem!
- **Swagger documentation**: Interactive docs that let you test everything right in your browser
- **Health check**: Want to make sure everything's running? Just check the health endpoint
- **Static file serving**: I serve up that beautiful test interface directly from the API

## Final Thoughts

I built this API to be simple, fun, and actually useful. Whether you're learning web development, need a quick way to manage game data, or just want to play around with a REST API, this should do the trick!

Got questions? Found a bug? Want to suggest improvements? Feel free to dive into the code and make it your own. Happy coding! 🚀

## 📋 How to Run This Project (If You Cloned It)

Just cloned this repository? Awesome! Here's how to get it up and running in no time:

### Prerequisites
- **.NET 9.0 SDK** - Download from [Microsoft's website](https://dotnet.microsoft.com/download/dotnet/9.0) if you don't have it
- **Git** (obviously, since you cloned it!)

### Quick Start Guide

1. **Open your terminal/command prompt** and navigate to the project folder:
   ```bash
   cd path/to/GameApiASP.NET
   ```

2. **Restore the NuGet packages** (this downloads all the dependencies):
   ```bash
   dotnet restore
   ```

3. **Run the application**:
   ```bash
   dotnet run
   ```

4. **That's it!** 🎉 The API will start running and you'll see something like:
   ```
   Now listening on: http://localhost:5088
   Application started. Press Ctrl+C to shut down.
   ```

### Where to Go Next

Once it's running, open your browser and visit:
- **Main Interface**: http://localhost:5088
- **API Documentation**: http://localhost:5088/swagger
- **Health Check**: http://localhost:5088/health

### Troubleshooting

**Getting an error?** Here are the most common fixes:

- **Make sure you have .NET 9.0 SDK installed**: Run `dotnet --version` to check
- **Port already in use?** The app will usually pick a different port automatically
- **Permission issues?** Try running your terminal as administrator (Windows) or with `sudo` (Mac/Linux)

**Still having issues?** Open an issue on the GitHub repository and I'll help you out!
