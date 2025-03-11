using AutoMapper;
using EdunovaAPP.Controllers;
using EdunovaAPP.Data;
using EdunovaAPP.Models;
using EdunovaAPP.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace EdunovaAPP.Tests.Controllers
{

    /// <summary>
    /// Test klasa za GrupaController sadrži testove za sve akcije kontrolera.
    /// </summary>
    public class GrupaControllerTests
    {
        private readonly DbContextOptions<EdunovaContext> _options;
        private readonly EdunovaContext _context;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GrupaController _controller;

        /// <summary>
        /// Konstruktor koji inicijalizira testni kontekst i zavisnosti.
        /// </summary>
        public GrupaControllerTests()
        {
            _options = new DbContextOptionsBuilder<EdunovaContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_" + Guid.NewGuid().ToString())
                .Options;

            _context = new EdunovaContext(_options);
            _mapperMock = new Mock<IMapper>();
            _controller = new GrupaController(_context, _mapperMock.Object);
        }

        /// <summary>
        /// Testira metodu Get() koja vraća OK rezultat s listom grupa.
        /// </summary>
        [Fact]
        public void Get_ReturnsOkWithGrupaList()
        {
            var smjer = new Smjer { Sifra = 1, Naziv = "Test Smjer" };
            _context.Smjerovi.Add(smjer);
            _context.SaveChanges();

            var grupe = new List<Grupa>
                {
                    new () { Sifra = 1, Naziv = "Grupa 1", Smjer = smjer, MaksimalnoPolaznika = 20 },
                    new () { Sifra = 2, Naziv = "Grupa 2", Smjer = smjer, MaksimalnoPolaznika = 15 }
                };

            _context.Grupe.AddRange(grupe);
            _context.SaveChanges();

            var grupeDTO = new List<GrupaDTORead>
                {
                    new (1, "Grupa 1", "Test Smjer", null, 20),
                    new (2, "Grupa 2", "Test Smjer", null, 15)
                };

            

            _mapperMock.Setup(m => m.Map<List<GrupaDTORead>>(It.IsAny<IEnumerable<Grupa>>()))
                .Returns(grupeDTO);

            // Act
            var result = _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedGrupe = Assert.IsType<List<GrupaDTORead>>(okResult.Value);
            Assert.Equal(2, returnedGrupe.Count);
        }

        /// <summary>
        /// Testira metodu GetBySifra() kod postojeće grupe; očekuje OK rezultat s grupom.
        /// </summary>
        [Fact]
        public void GetBySifra_ExistingGrupa_ReturnsOkWithGrupa()
        {
            // Arrange
            var smjer = new Smjer { Sifra = 1, Naziv = "Test Smjer" };
            _context.Smjerovi.Add(smjer);
            _context.SaveChanges();

            var grupa = new Grupa { Sifra = 1, Naziv = "Test Grupa", Smjer = smjer, MaksimalnoPolaznika = 20 };
            var grupaDTO = new GrupaDTOInsertUpdate("Test Grupa", 1, null, 20);

            _context.Grupe.Add(grupa);
            _context.SaveChanges();

            _mapperMock.Setup(m => m.Map<GrupaDTOInsertUpdate>(It.IsAny<Grupa>()))
                .Returns(grupaDTO);

            // Act
            var result = _controller.GetBySifra(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedGrupa = Assert.IsType<GrupaDTOInsertUpdate>(okResult.Value);
            Assert.Equal("Test Grupa", returnedGrupa.Naziv);
        }

        /// <summary>
        /// Testira metodu GetBySifra() za nepostojeću grupu; očekuje NotFound rezultat.
        /// </summary>
        [Fact]
        public void GetBySifra_NonExistingGrupa_ReturnsNotFound()
        {
            // Act
            var result = _controller.GetBySifra(999);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        /// <summary>
        /// Testira metodu Post() za validnu grupu; očekuje Created rezultat s novokreiranom grupom.
        /// </summary>
        [Fact]
        public void Post_ValidGrupa_ReturnsCreatedWithGrupa()
        {
            // Arrange
            var smjer = new Smjer { Sifra = 1, Naziv = "Test Smjer" };
            _context.Smjerovi.Add(smjer);
            _context.SaveChanges();

            var grupaDTO = new GrupaDTOInsertUpdate("New Grupa", 1, null, 20);
            var grupa = new Grupa { Sifra = 1, Naziv = "New Grupa", Smjer = smjer, MaksimalnoPolaznika = 20 };
            var grupaReadDTO = new GrupaDTORead(1, "New Grupa", "Test Smjer", null, 20);

            _mapperMock.Setup(m => m.Map<Grupa>(grupaDTO))
                .Returns(grupa);
            _mapperMock.Setup(m => m.Map<GrupaDTORead>(It.IsAny<Grupa>()))
                .Returns(grupaReadDTO);

            // Act
            var result = _controller.Post(grupaDTO);

            // Assert
            var createdResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status201Created, createdResult.StatusCode);
            var returnedGrupa = Assert.IsType<GrupaDTORead>(createdResult.Value);
            Assert.Equal("New Grupa", returnedGrupa.Naziv);
        }

        /// <summary>
        /// Testira metodu Post() za slučaj kada ne postoji Smjer; očekuje NotFound rezultat.
        /// </summary>
        [Fact]
        public void Post_NonExistingSmjer_ReturnsNotFound()
        {
            // Arrange
            var grupaDTO = new GrupaDTOInsertUpdate("New Grupa", 999, null, 20);

            // Act
            var result = _controller.Post(grupaDTO);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        /// <summary>
        /// Testira metodu Put() za postojeću grupu; očekuje OK rezultat s porukom o uspješnoj promjeni.
        /// </summary>
        [Fact]
        public void Put_ExistingGrupa_ReturnsOkWithSuccessMessage()
        {
            // Arrange
            // First create and save a Smjer
            var smjer = new Smjer { Sifra = 1, Naziv = "Test Smjer" };
            _context.Smjerovi.Add(smjer);
            _context.SaveChanges();

            // Then create and save a Grupa with that Smjer
            var grupa = new Grupa { 
                Sifra = 1, 
                Naziv = "Original Grupa", 
                Smjer = smjer, 
                MaksimalnoPolaznika = 20 
            };
            _context.Grupe.Add(grupa);
            _context.SaveChanges();

            // Create the DTO for updating
            var grupaDTO = new GrupaDTOInsertUpdate("Updated Grupa", 1, "Novi Predavač", 25);
            
            // Mock the mapper to return the updated entity
            _mapperMock.Setup(m => m.Map(It.IsAny<GrupaDTOInsertUpdate>(), It.IsAny<Grupa>()))
                .Callback<GrupaDTOInsertUpdate, Grupa>((src, dest) => {
                    dest.Naziv = src.Naziv;
                    dest.Predavac = src.Predavac;
                    dest.MaksimalnoPolaznika = src.MaksimalnoPolaznika;
                })
                .Returns(grupa);

            // Act
            var result = _controller.Put(1, grupaDTO);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Contains("Uspješno promjenjeno", okResult.Value.ToString());
        }

        /// <summary>
        /// Testira metodu Put() za nepostojeću grupu; očekuje NotFound rezultat.
        /// </summary>
        [Fact]
        public void Put_NonExistingGrupa_ReturnsNotFound()
        {
            // Arrange
            var grupaDTO = new GrupaDTOInsertUpdate("Updated Grupa", 1, null, 20);

            // Act
            var result = _controller.Put(999, grupaDTO);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        /// <summary>
        /// Testira metodu Delete() za postojeću grupu; očekuje OK rezultat s porukom o uspješnom brisanju.
        /// </summary>
        [Fact]
        public void Delete_ExistingGrupa_ReturnsOkWithSuccessMessage()
        {
            // Arrange
            var smjer = new Smjer { Sifra = 1, Naziv = "Test Smjer" };
            _context.Smjerovi.Add(smjer);
            _context.SaveChanges();

            var grupa = new Grupa { Sifra = 1, Naziv = "Test Grupa", Smjer = smjer, MaksimalnoPolaznika = 20 };

            _context.Grupe.Add(grupa);
            _context.SaveChanges();

            // Act
            var result = _controller.Delete(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Contains("Uspješno obrisano", okResult.Value.ToString());
        }

        /// <summary>
        /// Testira metodu Delete() za nepostojeću grupu; očekuje NotFound rezultat.
        /// </summary>
        [Fact]
        public void Delete_NonExistingGrupa_ReturnsNotFound()
        {
            // Act
            var result = _controller.Delete(999);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        /// <summary>
        /// Testira metodu GetPolaznici() za postojeću grupu; očekuje OK rezultat s listom polaznika.
        /// </summary>
        [Fact]
        public void GetPolaznici_ExistingGrupa_ReturnsOkWithPolaznici()
        {
            // Arrange
            var smjer = new Smjer { Sifra = 1, Naziv = "Test Smjer" };
            _context.Smjerovi.Add(smjer);
            _context.SaveChanges();

            var grupa = new Grupa { Sifra = 1, Naziv = "Test Grupa", Smjer = smjer, MaksimalnoPolaznika = 20 };
            _context.Grupe.Add(grupa);
            _context.SaveChanges();

            var polaznici = new List<Polaznik>
                {
                    new () { Sifra = 1, Ime = "Test1", Prezime = "Polaznik1", Email = "test1@example.com" },
                    new () { Sifra = 2, Ime = "Test2", Prezime = "Polaznik2", Email = "test2@example.com" }
                };
            _context.Polaznici.AddRange(polaznici);
            _context.SaveChanges();

            // Dodavanje polaznika u grupu
            grupa.Polaznici = [.. polaznici];
            _context.Grupe.Update(grupa);
            _context.SaveChanges();

            var polazniciDTO = new List<PolaznikDTORead>
                {
                    new (1, "Test1", "Polaznik1", "test1@example.com", null, null),
                    new (2, "Test2", "Polaznik2", "test2@example.com", null, null)
                };

            _mapperMock.Setup(m => m.Map<List<PolaznikDTORead>>(It.IsAny<IEnumerable<Polaznik>>()))
                .Returns(polazniciDTO);

            // Act
            var result = _controller.GetPolaznici(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedPolaznici = Assert.IsType<List<PolaznikDTORead>>(okResult.Value);
            Assert.Equal(2, returnedPolaznici.Count);
        }

        /// <summary>
        /// Testira metodu GetPolaznici() za nepostojeću grupu; očekuje BadRequest rezultat.
        /// </summary>
        [Fact]
        public void GetPolaznici_NonExistingGrupa_ReturnsBadRequest()
        {
            // Act
            var result = _controller.GetPolaznici(999);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        /// <summary>
        /// Testira metodu DodajPolaznika() s važećim parametrima; očekuje OK rezultat s porukom o uspješnom dodavanju polaznika.
        /// </summary>
        [Fact]
        public void DodajPolaznika_ValidParameters_ReturnsOkWithSuccessMessage()
        {
            // Arrange
            var smjer = new Smjer { Sifra = 1, Naziv = "Test Smjer" };
            _context.Smjerovi.Add(smjer);
            _context.SaveChanges();

            var grupa = new Grupa { Sifra = 1, Naziv = "Test Grupa", Smjer = smjer, MaksimalnoPolaznika = 20, Polaznici = new List<Polaznik>() };
            _context.Grupe.Add(grupa);
            _context.SaveChanges();

            var polaznik = new Polaznik { Sifra = 1, Ime = "Test", Prezime = "Polaznik", Email = "test@example.com" };
            _context.Polaznici.Add(polaznik);
            _context.SaveChanges();

            // Act
            var result = _controller.DodajPolaznika(1, 1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Contains("Polaznik Polaznik Test dodan na grupu Test Grupa", okResult.Value.ToString());
        }

        /// <summary>
        /// Testira metodu DodajPolaznika() za nepostojeću grupu; očekuje BadRequest rezultat.
        /// </summary>
        [Fact]
        public void DodajPolaznika_NonExistingGrupa_ReturnsBadRequest()
        {
            // Arrange
            var polaznik = new Polaznik { Sifra = 1, Ime = "Test", Prezime = "Polaznik", Email = "test@example.com" };
            _context.Polaznici.Add(polaznik);
            _context.SaveChanges();

            // Act
            var result = _controller.DodajPolaznika(999, 1);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        /// <summary>
        /// Testira metodu DodajPolaznika() za nepostojećeg polaznika; očekuje BadRequest rezultat.
        /// </summary>
        [Fact]
        public void DodajPolaznika_NonExistingPolaznik_ReturnsBadRequest()
        {
            // Arrange
            var smjer = new Smjer { Sifra = 1, Naziv = "Test Smjer" };
            _context.Smjerovi.Add(smjer);
            _context.SaveChanges();

            var grupa = new Grupa { Sifra = 1, Naziv = "Test Grupa", Smjer = smjer, MaksimalnoPolaznika = 20 };
            _context.Grupe.Add(grupa);
            _context.SaveChanges();

            // Act
            var result = _controller.DodajPolaznika(1, 999);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        /// <summary>
        /// Testira metodu ObrisiPolaznika() s važećim parametrima; očekuje OK rezultat s porukom o uspješnom brisanju polaznika iz grupe.
        /// </summary>
        [Fact]
        public void ObrisiPolaznika_ValidParameters_ReturnsOkWithSuccessMessage()
        {
            // Arrange
            var smjer = new Smjer { Sifra = 1, Naziv = "Test Smjer" };
            _context.Smjerovi.Add(smjer);
            _context.SaveChanges();

            var polaznik = new Polaznik { Sifra = 1, Ime = "Test", Prezime = "Polaznik", Email = "test@example.com" };
            _context.Polaznici.Add(polaznik);
            _context.SaveChanges();

            var grupa = new Grupa { Sifra = 1, Naziv = "Test Grupa", Smjer = smjer, MaksimalnoPolaznika = 20, Polaznici = new List<Polaznik> { polaznik } };
            _context.Grupe.Add(grupa);
            _context.SaveChanges();

            // Act
            var result = _controller.ObrisiPolaznika(1, 1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Contains("Polaznik Polaznik Test obrisan iz grupe Test Grupa", okResult.Value.ToString());
        }

        /// <summary>
        /// Testira metodu GrafGrupe() koja dohvaća podatke za graf grupa; očekuje OK rezultat s grafom grupa.
        /// </summary>
        [Fact]
        public void GrafGrupe_ReturnsOkWithGrafGrupaList()
        {
            // Arrange
            var smjer = new Smjer { Sifra = 1, Naziv = "Test Smjer" };
            _context.Smjerovi.Add(smjer);
            _context.SaveChanges();

            var polaznici = new List<Polaznik>
                {
                    new Polaznik { Sifra = 1, Ime = "Test1", Prezime = "Polaznik1", Email = "test1@example.com" },
                    new Polaznik { Sifra = 2, Ime = "Test2", Prezime = "Polaznik2", Email = "test2@example.com" }
                };
            _context.Polaznici.AddRange(polaznici);
            _context.SaveChanges();

            var grupa = new Grupa { Sifra = 1, Naziv = "Test Grupa", Smjer = smjer, MaksimalnoPolaznika = 20, Polaznici = new List<Polaznik>(polaznici) };
            _context.Grupe.Add(grupa);
            _context.SaveChanges();

            var grafGrupaDTO = new List<GrafGrupaDTO>
                {
                    new GrafGrupaDTO("Test Grupa", 2)
                };

            _mapperMock.Setup(m => m.Map<List<GrafGrupaDTO>>(It.IsAny<IEnumerable<Grupa>>()))
                .Returns(grafGrupaDTO);

            // Act
            var result = _controller.GrafGrupe();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedGrafGrupe = Assert.IsType<List<GrafGrupaDTO>>(okResult.Value);
            Assert.Single(returnedGrafGrupe);
            Assert.Equal("Test Grupa", returnedGrafGrupe[0].NazivGrupe);
            Assert.Equal(2, returnedGrafGrupe[0].UkupnoPolaznika);
        }
    }
}
