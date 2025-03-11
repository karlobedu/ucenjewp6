using AutoMapper;
using EdunovaAPP.Controllers;
using EdunovaAPP.Data;
using EdunovaAPP.Models;
using EdunovaAPP.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace EdunovaAPP.Tests.Controllers
{

    /// <summary>
    /// Test klasa za PolaznikController.
    /// Sadrži testove za sve REST API metode unutar kontrolera.
    /// </summary>
    public class PolaznikControllerTests
    {
        private readonly DbContextOptions<EdunovaContext> _options;
        private readonly EdunovaContext _context;
        private readonly Mock<IMapper> _mapperMock;
        private readonly PolaznikController _controller;

        /// <summary>
        /// Konstruktor klase, postavlja in-memory bazu podataka, mapper te instancu kontrolera.
        /// </summary>
        public PolaznikControllerTests()
        {
            _options = new DbContextOptionsBuilder<EdunovaContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_" + Guid.NewGuid().ToString())
                .Options;

            _context = new EdunovaContext(_options);
            _mapperMock = new Mock<IMapper>();
            _controller = new PolaznikController(_context, _mapperMock.Object);
        }

        /// <summary>
        /// Testira GET metodu koja vraća listu polaznika i osigurava da se vraćeni rezultat ispravno mapira.
        /// </summary>
        [Fact]
        public void Get_ReturnsOkWithPolaznikList()
        {
            // Arrange
            var polaznici = new List<Polaznik>
                {
                    new() { Sifra = 1, Ime = "Test", Prezime = "Polaznik1", Email = "test1@example.com" },
                    new() { Sifra = 2, Ime = "Test", Prezime = "Polaznik2", Email = "test2@example.com" }
                };

            var polazniciDTO = new List<PolaznikDTORead>
                {
                    new(1, "Test", "Polaznik1", "test1@example.com", null, null),
                    new(2, "Test", "Polaznik2", "test2@example.com", null, null)
                };

            _context.Polaznici.AddRange(polaznici);
            _context.SaveChanges();

            _mapperMock.Setup(m => m.Map<List<PolaznikDTORead>>(It.IsAny<IEnumerable<Polaznik>>()))
                .Returns(polazniciDTO);

            // Act
            var result = _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedPolaznici = Assert.IsType<List<PolaznikDTORead>>(okResult.Value);
            Assert.Equal(2, returnedPolaznici.Count);
        }

        /// <summary>
        /// Testira GET metodu koja dohvaća polaznika prema šifri kada polaznik postoji.
        /// Provjerava jesu li vraćeni podaci ispravni.
        /// </summary>
        [Fact]
        public void GetBySifra_ExistingPolaznik_ReturnsOkWithPolaznik()
        {
            // Arrange
            var polaznik = new Polaznik { Sifra = 1, Ime = "Test", Prezime = "Polaznik", Email = "test@example.com" };
            var polaznikDTO = new PolaznikDTOInsertUpdate("Test", "Polaznik", "test@example.com", null);

            _context.Polaznici.Add(polaznik);
            _context.SaveChanges();

            _mapperMock.Setup(m => m.Map<PolaznikDTOInsertUpdate>(It.IsAny<Polaznik>()))
                .Returns(polaznikDTO);

            // Act
            var result = _controller.GetBySifra(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedPolaznik = Assert.IsType<PolaznikDTOInsertUpdate>(okResult.Value);
            Assert.Equal("Test", returnedPolaznik.Ime);
            Assert.Equal("Polaznik", returnedPolaznik.Prezime);
        }

        /// <summary>
        /// Testira GET metodu kada polaznik s danom šifrom ne postoji.
        /// Očekuje NotFound rezultat.
        /// </summary>
        [Fact]
        public void GetBySifra_NonExistingPolaznik_ReturnsNotFound()
        {
            // Act
            var result = _controller.GetBySifra(999);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        /// <summary>
        /// Testira POST metodu za dodavanje novog polaznika.
        /// Provjerava se kreiranje polaznika i vraćanje ispravnih podataka.
        /// </summary>
        [Fact]
        public void Post_ValidPolaznik_ReturnsCreatedWithPolaznik()
        {
            // Arrange
            var polaznikDTO = new PolaznikDTOInsertUpdate("New", "Polaznik", "new@example.com", null);
            var polaznik = new Polaznik { Sifra = 1, Ime = "New", Prezime = "Polaznik", Email = "new@example.com" };
            var polaznikReadDTO = new PolaznikDTORead(1, "New", "Polaznik", "new@example.com", null, null);

            _mapperMock.Setup(m => m.Map<Polaznik>(polaznikDTO))
                .Returns(polaznik);
            _mapperMock.Setup(m => m.Map<PolaznikDTORead>(It.IsAny<Polaznik>()))
                .Returns(polaznikReadDTO);

            // Act
            var result = _controller.Post(polaznikDTO);

            // Assert
            var createdResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status201Created, createdResult.StatusCode);
            var returnedPolaznik = Assert.IsType<PolaznikDTORead>(createdResult.Value);
            Assert.Equal("New", returnedPolaznik.Ime);
            Assert.Equal("Polaznik", returnedPolaznik.Prezime);
        }

        /// <summary>
        /// Testira PUT metodu za ažuriranje postojećeg polaznika.
        /// Provjerava se uspješnost promjene podataka.
        /// </summary>
        [Fact]
        public void Put_ExistingPolaznik_ReturnsOkWithSuccessMessage()
        {
            // Arrange
            var polaznik = new Polaznik { Sifra = 1, Ime = "Original", Prezime = "Polaznik", Email = "original@example.com" };
            var polaznikDTO = new PolaznikDTOInsertUpdate("Updated", "Polaznik", "updated@example.com", null);
            var updatedPolaznik = new Polaznik { Sifra = 1, Ime = "Updated", Prezime = "Polaznik", Email = "updated@example.com" };

            _context.Polaznici.Add(polaznik);
            _context.SaveChanges();

            _mapperMock.Setup(m => m.Map(polaznikDTO, It.IsAny<Polaznik>()))
                .Returns(updatedPolaznik);

            _mapperMock.Setup(m => m.Map(It.IsAny<PolaznikDTOInsertUpdate>(), It.IsAny<Polaznik>()))
                .Callback<PolaznikDTOInsertUpdate, Polaznik>((src, dest) => {
                    dest.Ime = src.Ime;
                    dest.Prezime = src.Prezime;
                    dest.Email = src.Email;
                    dest.Oib = src.Oib;
                })
                .Returns(polaznik);

            // Act
            var result = _controller.Put(1, polaznikDTO);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Contains("Uspješno promjenjeno", okResult.Value.ToString());
        }

        /// <summary>
        /// Testira PUT metodu za ažuriranje polaznika koji ne postoji.
        /// Očekuje NotFound rezultat.
        /// </summary>
        [Fact]
        public void Put_NonExistingPolaznik_ReturnsNotFound()
        {
            // Arrange
            var polaznikDTO = new PolaznikDTOInsertUpdate("Updated", "Polaznik", "updated@example.com", null);

            // Act
            var result = _controller.Put(999, polaznikDTO);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        /// <summary>
        /// Testira DELETE metodu za brisanje postojećeg polaznika.
        /// Provjerava se uspješno brisanje i odgovarajuća poruka.
        /// </summary>
        [Fact]
        public void Delete_ExistingPolaznik_ReturnsOkWithSuccessMessage()
        {
            // Arrange
            var polaznik = new Polaznik { Sifra = 1, Ime = "Test", Prezime = "Polaznik", Email = "test@example.com" };

            _context.Polaznici.Add(polaznik);
            _context.SaveChanges();

            // Act
            var result = _controller.Delete(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Contains("Uspješno obrisano", okResult.Value.ToString());
        }

        /// <summary>
        /// Testira DELETE metodu kada polaznik ne postoji.
        /// Očekuje NotFound rezultat.
        /// </summary>
        [Fact]
        public void Delete_NonExistingPolaznik_ReturnsNotFound()
        {
            // Act
            var result = _controller.Delete(999);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        /// <summary>
        /// Testira metodu TraziPolaznik koja vraća listu polaznika prema zadanom uvjetu pretrage.
        /// Provjerava se ispravnost filtriranja po uvjetu.
        /// </summary>
        [Fact]
        public void TraziPolaznik_ValidSearchTerm_ReturnsMatchingPolaznici()
        {
            // Arrange
            var polaznici = new List<Polaznik>
                {
                    new () { Sifra = 1, Ime = "Ivan", Prezime = "Horvat", Email = "ivan@example.com" },
                    new () { Sifra = 2, Ime = "Marko", Prezime = "Ivić", Email = "marko@example.com" },
                    new () { Sifra = 3, Ime = "Ana", Prezime = "Horvat", Email = "ana@example.com" }
                };

            _context.Polaznici.AddRange(polaznici);
            _context.SaveChanges();

            var matchingPolazniciDTO = new List<PolaznikDTORead>
                {
                    new(1, "Ivan", "Horvat", "ivan@example.com", null, null),
                    new(3, "Ana", "Horvat", "ana@example.com", null, null)
                };

            _mapperMock.Setup(m => m.Map<List<PolaznikDTORead>>(It.IsAny<IEnumerable<Polaznik>>()))
                .Returns(matchingPolazniciDTO);

            // Act
            var result = _controller.TraziPolaznik("horvat");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedPolaznici = Assert.IsType<List<PolaznikDTORead>>(okResult.Value);
            Assert.Equal(2, returnedPolaznici.Count);
        }

        /// <summary>
        /// Testira metodu TraziPolaznik kada je uvjet pretraživanja prekratak.
        /// Očekuje BadRequest rezultat.
        /// </summary>
        [Fact]
        public void TraziPolaznik_ShortSearchTerm_ReturnsBadRequest()
        {
            // Act
            var result = _controller.TraziPolaznik("ab");

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        /// <summary>
        /// Testira metodu TraziPolaznikStranicenje koja vraća paginirane rezultate.
        /// Provjerava se ispravnost paginacije.
        /// </summary>
        [Fact]
        public void TraziPolaznikStranicenje_ValidParameters_ReturnsPagedResults()
        {
            // Arrange
            var polaznici = new List<Polaznik>();
            for (int i = 1; i <= 100; i++)
            {
                polaznici.Add(new Polaznik
                {
                    Sifra = i,
                    Ime = $"Test{i}",
                    Prezime = $"Polaznik{i}",
                    Email = $"test{i}@example.com"
                });
            }

            _context.Polaznici.AddRange(polaznici);
            _context.SaveChanges();

            // Create a list of polaznici that should be returned for page 2 (items 5-8)
            var skippedPolaznici = polaznici.Skip(4).Take(4).ToList();
            
            var pagedPolazniciDTO = new List<PolaznikDTORead>
                {
                    new (5, "Test5", "Polaznik5", "test5@example.com", null, null),
                    new (6, "Test6", "Polaznik6", "test6@example.com", null, null),
                    new (7, "Test7", "Polaznik7", "test7@example.com", null, null),
                    new (8, "Test8", "Polaznik8", "test8@example.com", null, null)
                };

            // Setup the mapper to return the correct DTOs when given the skipped and taken polaznici
            _mapperMock.Setup(m => m.Map<List<PolaznikDTORead>>(It.Is<IEnumerable<Polaznik>>(p => 
                p.Count() == 4 && p.First().Sifra == 5 && p.Last().Sifra == 8)))
                .Returns(pagedPolazniciDTO);

            // Act
            var result = _controller.TraziPolaznikStranicenje(2,"");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedPolaznici = Assert.IsType<List<PolaznikDTORead>>(okResult.Value);
            Assert.Equal(4, returnedPolaznici.Count);
            Assert.Equal(5, returnedPolaznici[0].Sifra);
            Assert.Equal(8, returnedPolaznici[3].Sifra);
        }
    }
}
