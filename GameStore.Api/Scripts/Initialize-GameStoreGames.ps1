param(
    [string]$Hostname = "localhost",
    [int]$Port = 5177
)

$uri = "http://${Hostname}:${Port}/games"

$games = @(
    @{ name = "Final Fantasy VII"; genreId = 1; price = 39.99; releaseDate = "1997-01-31" },
    @{ name = "Chrono Trigger"; genreId = 1; price = 29.99; releaseDate = "1995-03-11" },
    @{ name = "Dragon Quest XI"; genreId = 1; price = 49.99; releaseDate = "2017-07-29" },
    @{ name = "Persona 5"; genreId = 1; price = 59.99; releaseDate = "2016-09-15" },
    @{ name = "Xenoblade Chronicles"; genreId = 1; price = 49.99; releaseDate = "2010-06-10" },
    @{ name = "EarthBound"; genreId = 1; price = 24.99; releaseDate = "1994-08-27" },
    @{ name = "Secret of Mana"; genreId = 1; price = 19.99; releaseDate = "1993-08-06" },
    @{ name = "Suikoden II"; genreId = 1; price = 34.99; releaseDate = "1998-12-17" },
    @{ name = "Tales of Symphonia"; genreId = 1; price = 24.99; releaseDate = "2003-08-29" },
    @{ name = "Ni no Kuni"; genreId = 1; price = 29.99; releaseDate = "2011-11-17" },

    @{ name = "Fire Emblem Awakening"; genreId = 2; price = 39.99; releaseDate = "2012-04-19" },
    @{ name = "Final Fantasy Tactics"; genreId = 2; price = 24.99; releaseDate = "1997-06-20" },
    @{ name = "Tactics Ogre"; genreId = 2; price = 29.99; releaseDate = "1995-10-06" },
    @{ name = "XCOM Enemy Unknown"; genreId = 2; price = 19.99; releaseDate = "2012-10-09" },
    @{ name = "Advance Wars"; genreId = 2; price = 19.99; releaseDate = "2001-09-10" },
    @{ name = "Disgaea"; genreId = 2; price = 24.99; releaseDate = "2003-01-30" },
    @{ name = "Triangle Strategy"; genreId = 2; price = 49.99; releaseDate = "2022-03-04" },
    @{ name = "Valkyria Chronicles"; genreId = 2; price = 19.99; releaseDate = "2008-04-24" },
    @{ name = "Into the Breach"; genreId = 2; price = 14.99; releaseDate = "2018-02-27" },
    @{ name = "Mario Plus Rabbids"; genreId = 2; price = 39.99; releaseDate = "2017-08-29" },

    @{ name = "Mario Kart 8 Deluxe"; genreId = 3; price = 59.99; releaseDate = "2017-04-28" },
    @{ name = "Gran Turismo 4"; genreId = 3; price = 19.99; releaseDate = "2004-12-28" },
    @{ name = "Forza Horizon 5"; genreId = 3; price = 59.99; releaseDate = "2021-11-09" },
    @{ name = "Need for Speed Most Wanted"; genreId = 3; price = 19.99; releaseDate = "2005-11-11" },
    @{ name = "Burnout 3 Takedown"; genreId = 3; price = 14.99; releaseDate = "2004-09-07" },
    @{ name = "F Zero GX"; genreId = 3; price = 24.99; releaseDate = "2003-07-25" },
    @{ name = "Diddy Kong Racing"; genreId = 3; price = 19.99; releaseDate = "1997-11-21" },
    @{ name = "Ridge Racer Type 4"; genreId = 3; price = 14.99; releaseDate = "1998-12-03" },
    @{ name = "Wipeout XL"; genreId = 3; price = 14.99; releaseDate = "1996-09-30" },
    @{ name = "OutRun 2006"; genreId = 3; price = 19.99; releaseDate = "2006-03-31" },

    @{ name = "The Legend of Zelda BOTW"; genreId = 4; price = 59.99; releaseDate = "2017-03-03" },
    @{ name = "Grand Theft Auto V"; genreId = 4; price = 29.99; releaseDate = "2013-09-17" },
    @{ name = "God of War"; genreId = 4; price = 39.99; releaseDate = "2018-04-20" },
    @{ name = "Devil May Cry 5"; genreId = 4; price = 39.99; releaseDate = "2019-03-08" },
    @{ name = "Metal Gear Solid"; genreId = 4; price = 19.99; releaseDate = "1998-09-03" },
    @{ name = "Bayonetta"; genreId = 4; price = 19.99; releaseDate = "2009-10-29" },
    @{ name = "Batman Arkham City"; genreId = 4; price = 19.99; releaseDate = "2011-10-18" },
    @{ name = "Spider Man"; genreId = 4; price = 39.99; releaseDate = "2018-09-07" },
    @{ name = "Ninja Gaiden Black"; genreId = 4; price = 14.99; releaseDate = "2005-09-20" },
    @{ name = "Hades"; genreId = 4; price = 24.99; releaseDate = "2020-09-17" },
    @{ name = "Elden Ring"; genreId = 4; price = 59.99; releaseDate = "2022-02-25" },
    @{ name = "Sekiro Shadows Die Twice"; genreId = 4; price = 59.99; releaseDate = "2019-03-22" },
    @{ name = "Dark Souls"; genreId = 4; price = 39.99; releaseDate = "2011-09-22" },
    @{ name = "Assassins Creed II"; genreId = 4; price = 19.99; releaseDate = "2009-11-17" },
    @{ name = "Resident Evil 4"; genreId = 4; price = 39.99; releaseDate = "2005-01-11" },

    @{ name = "Silent Hill 2"; genreId = 5; price = 29.99; releaseDate = "2001-09-24" },
    @{ name = "Resident Evil"; genreId = 5; price = 19.99; releaseDate = "1996-03-22" },
    @{ name = "Resident Evil 2"; genreId = 5; price = 39.99; releaseDate = "1998-01-21" },
    @{ name = "Dead Space"; genreId = 5; price = 39.99; releaseDate = "2008-10-13" },
    @{ name = "Amnesia The Dark Descent"; genreId = 5; price = 19.99; releaseDate = "2010-09-08" },
    @{ name = "Outlast"; genreId = 5; price = 19.99; releaseDate = "2013-09-04" },
    @{ name = "Alien Isolation"; genreId = 5; price = 29.99; releaseDate = "2014-10-07" },
    @{ name = "Fatal Frame II"; genreId = 5; price = 24.99; releaseDate = "2003-11-27" },
    @{ name = "Until Dawn"; genreId = 5; price = 29.99; releaseDate = "2015-08-25" },
    @{ name = "The Evil Within"; genreId = 5; price = 19.99; releaseDate = "2014-10-14" },

    @{ name = "Gradius"; genreId = 6; price = 9.99; releaseDate = "1985-05-29" },
    @{ name = "R Type"; genreId = 6; price = 9.99; releaseDate = "1987-07-01" },
    @{ name = "Ikaruga"; genreId = 6; price = 14.99; releaseDate = "2001-12-20" },
    @{ name = "Radiant Silvergun"; genreId = 6; price = 19.99; releaseDate = "1998-05-28" },
    @{ name = "DoDonPachi"; genreId = 6; price = 14.99; releaseDate = "1997-02-05" },
    @{ name = "Raiden"; genreId = 6; price = 9.99; releaseDate = "1990-04-01" },
    @{ name = "Mushihimesama"; genreId = 6; price = 19.99; releaseDate = "2004-10-12" },
    @{ name = "Thunder Force IV"; genreId = 6; price = 14.99; releaseDate = "1992-07-24" },
    @{ name = "1942"; genreId = 6; price = 9.99; releaseDate = "1984-12-11" },
    @{ name = "Darius Gaiden"; genreId = 6; price = 14.99; releaseDate = "1994-09-19" },

    @{ name = "FIFA 23"; genreId = 7; price = 59.99; releaseDate = "2022-09-30" },
    @{ name = "Madden NFL 24"; genreId = 7; price = 59.99; releaseDate = "2023-08-18" },
    @{ name = "NBA 2K24"; genreId = 7; price = 59.99; releaseDate = "2023-09-08" },
    @{ name = "Tony Hawks Pro Skater 2"; genreId = 7; price = 19.99; releaseDate = "2000-09-20" },
    @{ name = "Wii Sports"; genreId = 7; price = 29.99; releaseDate = "2006-11-19" },
    @{ name = "Rocket League"; genreId = 7; price = 19.99; releaseDate = "2015-07-07" },
    @{ name = "Punch Out"; genreId = 7; price = 14.99; releaseDate = "1987-11-21" },
    @{ name = "NHL 94"; genreId = 7; price = 9.99; releaseDate = "1993-09-01" },
    @{ name = "Pro Evolution Soccer 6"; genreId = 7; price = 14.99; releaseDate = "2006-10-27" },
    @{ name = "Virtua Tennis"; genreId = 7; price = 9.99; releaseDate = "1999-12-01" },

    @{ name = "Super Mario World"; genreId = 8; price = 19.99; releaseDate = "1990-11-21" },
    @{ name = "Sonic the Hedgehog"; genreId = 8; price = 9.99; releaseDate = "1991-06-23" },
    @{ name = "Mega Man 2"; genreId = 8; price = 9.99; releaseDate = "1988-12-24" },
    @{ name = "Celeste"; genreId = 8; price = 19.99; releaseDate = "2018-01-25" },
    @{ name = "Hollow Knight"; genreId = 8; price = 14.99; releaseDate = "2017-02-24" },
    @{ name = "Donkey Kong Country"; genreId = 8; price = 19.99; releaseDate = "1994-11-18" },
    @{ name = "Castlevania Symphony"; genreId = 8; price = 19.99; releaseDate = "1997-03-20" },
    @{ name = "Super Metroid"; genreId = 8; price = 19.99; releaseDate = "1994-03-19" },
    @{ name = "Rayman Legends"; genreId = 8; price = 19.99; releaseDate = "2013-08-29" },
    @{ name = "Shovel Knight"; genreId = 8; price = 24.99; releaseDate = "2014-06-26" },
    @{ name = "Ori and the Blind Forest"; genreId = 8; price = 19.99; releaseDate = "2015-03-11" },
    @{ name = "Cuphead"; genreId = 8; price = 19.99; releaseDate = "2017-09-29" },

    @{ name = "The Secret of Monkey Island"; genreId = 9; price = 9.99; releaseDate = "1990-10-01" },
    @{ name = "King's Quest VI"; genreId = 9; price = 9.99; releaseDate = "1992-09-30" },
    @{ name = "Myst"; genreId = 9; price = 14.99; releaseDate = "1993-09-24" },
    @{ name = "Grim Fandango"; genreId = 9; price = 14.99; releaseDate = "1998-10-30" },
    @{ name = "The Longest Journey"; genreId = 9; price = 14.99; releaseDate = "1999-11-19" },
    @{ name = "Broken Sword"; genreId = 9; price = 9.99; releaseDate = "1996-09-30" },
    @{ name = "Syberia"; genreId = 9; price = 9.99; releaseDate = "2002-09-01" },
    @{ name = "Life is Strange"; genreId = 9; price = 19.99; releaseDate = "2015-01-30" },
    @{ name = "The Walking Dead"; genreId = 9; price = 19.99; releaseDate = "2012-04-24" },
    @{ name = "Return to Monkey Island"; genreId = 9; price = 24.99; releaseDate = "2022-09-19" },
    @{ name = "Phoenix Wright Ace Attorney"; genreId = 9; price = 19.99; releaseDate = "2001-10-12" },
    @{ name = "Disco Elysium"; genreId = 9; price = 39.99; releaseDate = "2019-10-15" },
    @{ name = "Outer Wilds"; genreId = 9; price = 24.99; releaseDate = "2019-05-28" }
)

$index = 0
foreach ($game in $games) {
    $index++
    $body = $game | ConvertTo-Json

    try {
        $response = Invoke-RestMethod -Uri $uri -Method Post -ContentType "application/json" -Body $body
        Write-Host "[$index/$($games.Count)] Created $($game.name) with id $($response.id)"
    }
    catch {
        Write-Error "[$index/$($games.Count)] Failed to create $($game.name): $($_.Exception.Message)"
    }
}
