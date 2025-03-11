using EdunovaAPP.Controllers;
using EdunovaAPP.Data;
using EdunovaAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EdunovaAPP.Tests.Controllers
{

    /// <summary>
    /// Test klasa za testiranje metode unutar PocetnaController.
    /// </summary>
    public class PocetnaControllerTests
    {
        private readonly DbContextOptions<EdunovaContext> _options;
        private readonly EdunovaContext _context;
        private readonly PocetnaController _controller;

        /// <summary>
        /// Konstruktor koji inicijalizira test kontekst i kontroler.
        /// </summary>
        public PocetnaControllerTests()
        {
            _options = new DbContextOptionsBuilder<EdunovaContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_" + Guid.NewGuid().ToString())
                .Options;

            _context = new EdunovaContext(_options);
            _controller = new PocetnaController(_context);
        }

        /// <summary>
        /// Testira metodu DostupniSmjerovi da vraæa Ok rezultat sa listom smjerova.
        /// </summary>
        [Fact]
        public void DostupniSmjerovi_ReturnsOkWithSmjerList()
        {
            // Arrange
            var smjerovi = new List<Smjer>
                {
                    new () { Sifra = 1, Naziv = "Smjer 1" },
                    new () { Sifra = 2, Naziv = "Smjer 2" },
                    new () { Sifra = 3, Naziv = "Smjer 3" }
                };

            _context.Smjerovi.AddRange(smjerovi);
            _context.SaveChanges();

            // Act
            var result = _controller.DostupniSmjerovi();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedSmjerovi = Assert.IsType<List<object>>(okResult.Value);
            Assert.Equal(3, returnedSmjerovi.Count);
        }

        /// <summary>
        /// Testira metodu DostupniSmjerovi kada baza ne sadrži podatke, te oèekuje praznu listu.
        /// </summary>
        [Fact]
        public void DostupniSmjerovi_EmptyDatabase_ReturnsEmptyList()
        {
            // Act
            var result = _controller.DostupniSmjerovi();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedSmjerovi = Assert.IsType<List<object>>(okResult.Value);
            Assert.Empty(returnedSmjerovi);
        }

        /// <summary>
        /// Testira metodu DostupniSmjerovi u sluèaju greške u bazi podataka, te oèekuje BadRequest rezultat.
        /// </summary>
        [Fact]
        public void DostupniSmjerovi_DatabaseError_ReturnsBadRequest()
        {
            // Arrange - Koristi se zbrisan kontekst za forsiranje iznimke
            _context.Dispose();

            // Act & Assert
            var result = _controller.DostupniSmjerovi();
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        /// <summary>
        /// Testira metodu UkupnoPolaznika da vraæa Ok rezultat sa ispravnim brojem polaznika.
        /// </summary>
        [Fact]
        public void UkupnoPolaznika_ReturnsOkWithCount()
        {
            // Arrange
            var polaznici = new List<Polaznik>
                {
                    new () { Sifra = 1, Ime = "Ime1", Prezime = "Prezime1", Email = "email1@example.com" },
                    new () { Sifra = 2, Ime = "Ime2", Prezime = "Prezime2", Email = "email2@example.com" },
                    new () { Sifra = 3, Ime = "Ime3", Prezime = "Prezime3", Email = "email3@example.com" }
                };

            _context.Polaznici.AddRange(polaznici);
            _context.SaveChanges();

            // Act
            var result = _controller.UkupnoPolaznika();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            dynamic returnValue = okResult.Value;
            Assert.Equal(3, returnValue.poruka);
        }

        /// <summary>
        /// Testira metodu UkupnoPolaznika kada baza ne sadrži podatke, te oèekuje da se vrati broj nula.
        /// </summary>
        [Fact]
        public void UkupnoPolaznika_EmptyDatabase_ReturnsZero()
        {
            // Act
            var result = _controller.UkupnoPolaznika();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            dynamic returnValue = okResult.Value;
            Assert.Equal(0, returnValue.poruka);
        }

        /// <summary>
        /// Testira metodu UkupnoPolaznika u sluèaju greške u bazi podataka, te oèekuje BadRequest rezultat.
        /// </summary>
        [Fact]
        public void UkupnoPolaznika_DatabaseError_ReturnsBadRequest()
        {
            // Arrange - Koristi se zbrisan kontekst za forsiranje iznimke
            _context.Dispose();

            // Act & Assert
            var result = _controller.UkupnoPolaznika();
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
