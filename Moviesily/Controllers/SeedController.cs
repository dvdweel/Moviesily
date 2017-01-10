using Moviesily.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Moviesily.Controllers
{
    public class SeedController : Controller
    {
        // GET: Seed
        public ActionResult AddGenres()
        {
            using (var db = new DatabaseContext())
            {
                db.Genres.Add(new Genre()
                {
                    GenreID = 1,
                    GenreName = "Action"
                });

                db.Genres.Add(new Genre()
                {
                    GenreID = 2,
                    GenreName = "Animation"
                });

                db.Genres.Add(new Genre()
                {
                    GenreID = 3,
                    GenreName = "Fantasy"
                });

                db.Genres.Add(new Genre()
                {
                    GenreID = 4,
                    GenreName = "Horror"
                });

                db.Genres.Add(new Genre()
                {
                    GenreID = 5,
                    GenreName = "Romance"
                });

                db.Genres.Add(new Genre()
                {
                    GenreID = 6,
                    GenreName = "Comedy"
                });

                db.Genres.Add(new Genre()
                {
                    GenreID = 7,
                    GenreName = "Sci-fi"
                });

                db.SaveChanges();
                return View();
            }
        }


        public ActionResult AddMovies()
        {
            using (var db = new DatabaseContext())
            {
                db.Movies.Add(new Movie()
                {
                    MovieID = 1,
                    Title = "Suicide Squad",
                    Director = "David Ayer",
                    ReleaseYear = 2016,
                    Language = "English",
                    Description = "A secret government agency recruits some of the most dangerous incarcerated super-villains to form a defensive task force. Their first mission: save the world from the apocalypse.",
                    Image = "../Images/suicidesquad.jpg",
                    GenreID = 1
                });

                db.Movies.Add(new Movie()
                {
                    MovieID = 2,
                    Title = "The Dark Knight",
                    Director = "Christopher Nolan",
                    ReleaseYear = 2008,
                    Language = "English",
                    Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, the caped crusader must come to terms with one of the greatest psychological tests of his ability to fight injustice.",
                    Image = "../Images/darkknight.jpg",
                    GenreID = 1
                });

                db.Movies.Add(new Movie()
                {
                    MovieID = 3,
                    Title = "Inception",
                    Director = "Christopher Nolan",
                    ReleaseYear = 2010,
                    Language = "English",
                    Description = "A thief, who steals corporate secrets through use of dream-sharing technology, is given the inverse task of planting an idea into the mind of a CEO.",
                    Image = "../Images/inception.jpg",
                    GenreID = 1
                });

                db.Movies.Add(new Movie()
                {
                    MovieID = 4,
                    Title = "The Lion King",
                    Director = "Roger Allers, Rob Minkoff",
                    ReleaseYear = 1994,
                    Language = "English",
                    Description = "Lion cub and future king Simba searches for his identity. His eagerness to please others and penchant for testing his boundaries sometimes gets him into trouble.",
                    Image = "../Images/thelionking.jpg",
                    GenreID = 2
                });

                db.Movies.Add(new Movie()
                {
                    MovieID = 5,
                    Title = "WALL-E",
                    Director = "Andrew Stanton",
                    ReleaseYear = 2008,
                    Language = "English",
                    Description = "In the distant future, a small waste-collecting robot inadvertently embarks on a space journey that will ultimately decide the fate of mankind.",
                    Image = "../Images/walle.jpg",
                    GenreID = 2
                });

                db.Movies.Add(new Movie()
                {
                    MovieID = 6,
                    Title = "Toy Story",
                    Director = "John Lasseter",
                    ReleaseYear = 1995,
                    Language = "English",
                    Description = "A cowboy doll is profoundly threatened and jealous when a new spaceman figure supplants him as top toy in a boy's room.",
                    Image = "../Images/toystory.jpg",
                    GenreID = 2
                });

                db.Movies.Add(new Movie()
                {
                    MovieID = 7,
                    Title = "The Lord of the Rings: The Return of the King",
                    Director = "Peter Jackson",
                    ReleaseYear = 2003,
                    Language = "English",
                    Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                    Image = "../Images/lordoftherings.jpg",
                    GenreID = 3
                });

                db.Movies.Add(new Movie()
                {
                    MovieID = 8,
                    Title = "Pan's Labyrinth",
                    Director = "Guillermo del Toro",
                    ReleaseYear = 2006,
                    Language = "Spanish",
                    Description = "In the falangist Spain of 1944, the bookish young stepdaughter of a sadistic army officer escapes into an eerie but captivating fantasy world.",
                    Image = "../Images/panslabyrinth.jpg",
                    GenreID = 3
                });

                db.Movies.Add(new Movie()
                {
                    MovieID = 9,
                    Title = "Harry Potter and the Deathly Hallows: Part 2",
                    Director = "David Yates",
                    ReleaseYear = 2011,
                    Language = "English",
                    Description = "Harry, Ron and Hermione search for Voldemort's remaining Horcruxes in their effort to destroy the Dark Lord as the final battle rages on at Hogwarts.",
                    Image = "../Images/harrypotter.jpg",
                    GenreID = 3
                });

                db.Movies.Add(new Movie()
                {
                    MovieID = 10,
                    Title = "Saw",
                    Director = "James Wan",
                    ReleaseYear = 2004,
                    Language = "English",
                    Description = "Two strangers awaken in a room with no recollection of how they got there or why, and soon discover they are pawns in a deadly game perpetrated by a notorious serial killer.",
                    Image = "../Images/saw.jpg",
                    GenreID = 4
                });

                db.Movies.Add(new Movie()
                {
                    MovieID = 11,
                    Title = "The Shining",
                    Director = "Stanley Kubrick",
                    ReleaseYear = 1980,
                    Language = "English",
                    Description = "A family heads to an isolated hotel for the winter where an evil and spiritual presence influences the father into violence, while his psychic son sees horrific forebodings from the past and of the future.",
                    Image = "../Images/theshining.jpg",
                    GenreID = 4
                });

                db.Movies.Add(new Movie()
                {
                    MovieID = 12,
                    Title = "Alien",
                    Director = "Ridley Scott",
                    ReleaseYear = 1979,
                    Language = "English",
                    Description = "After a space merchant vessel perceives an unknown transmission as distress call, their landing on the source moon finds one of the crew attacked by a mysterious lifeform.",
                    Image = "../Images/alien.jpg",
                    GenreID = 4
                });

                db.Movies.Add(new Movie()
                {
                    MovieID = 13,
                    Title = "The Sound Of Music",
                    Director = "Robert Wise",
                    ReleaseYear = 1965,
                    Language = "English",
                    Description = "A woman leaves an Austrian convent to become a governess to the children of a Naval officer widower.",
                    Image = "../Images/soundofmusic.jpg",
                    GenreID = 5
                });

                db.Movies.Add(new Movie()
                {
                    MovieID = 14,
                    Title = "Her",
                    Director = "Spike Jonze",
                    ReleaseYear = 2013,
                    Language = "English",
                    Description = "A lonely writer develops an unlikely relationship with an operating system designed to meet his every need.",
                    Image = "../Images/her.jpg",
                    GenreID = 5
                });

                db.Movies.Add(new Movie()
                {
                    MovieID = 15,
                    Title = "American Beauty",
                    Director = "Sam Mendes",
                    ReleaseYear = 1999,
                    Language = "English",
                    Description = "A sexually frustrated suburban father has a mid-life crisis after becoming infatuated with his daughter's best friend.",
                    Image = "../Images/americanbeauty.jpg",
                    GenreID = 5
                });

                db.Movies.Add(new Movie()
                {
                    MovieID = 16,
                    Title = "The Big Lebowski",
                    Director = "Joel Coen, Ethan Coen",
                    ReleaseYear = 1998,
                    Language = "English",
                    Description = "The Dude Lebowski, mistaken for a millionaire Lebowski, seeks restitution for his ruined rug and enlists his bowling buddies to help get it.",
                    Image = "../Images/biglebowski.jpg",
                    GenreID = 6
                });

                db.Movies.Add(new Movie()
                {
                    MovieID = 17,
                    Title = "The Wolf of Wall Street",
                    Director = "Martin Scorsese",
                    ReleaseYear = 2013,
                    Language = "English",
                    Description = "Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.",
                    Image = "../Images/thewolfofwallstreet.jpg",
                    GenreID = 6
                });

                db.Movies.Add(new Movie()
                {
                    MovieID = 18,
                    Title = "The Intouchables",
                    Director = "Olivier Nakache, Eric Toledano",
                    ReleaseYear = 2011,
                    Language = "French",
                    Description = "After he becomes a quadriplegic from a paragliding accident, an aristocrat hires a young man from the projects to be his caregiver.",
                    Image = "../Images/intouchables.jpg",
                    GenreID = 6
                });

                db.Movies.Add(new Movie()
                {
                    MovieID = 19,
                    Title = "Interstellar",
                    Director = "Christopher Nolan",
                    ReleaseYear = 2014,
                    Language = "English",
                    Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                    Image = "../Images/interstellar.jpg",
                    GenreID = 7
                });

                db.Movies.Add(new Movie()
                {
                    MovieID = 20,
                    Title = "The Matrix",
                    Director = "Lana Wachowski, Lilly Wachowski",
                    ReleaseYear = 1999,
                    Language = "English",
                    Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                    Image = "../Images/thematrix.jpg",
                    GenreID = 7
                });

                db.Movies.Add(new Movie()
                {
                    MovieID = 21,
                    Title = "Star Wars: Episode V - The Empire Strikes Back",
                    Director = "Irvin Kershner",
                    ReleaseYear = 1980,
                    Language = "English",
                    Description = "After the rebels have been brutally overpowered by the Empire on their newly established base, Luke Skywalker takes advanced Jedi training with Master Yoda, while his friends are pursued by Darth Vader as part of his plan to capture Luke.",
                    Image = "../Images/starwars.jpg",
                    GenreID = 7
                });
                
                db.SaveChanges();
                return View();
            }
        }
    }
}