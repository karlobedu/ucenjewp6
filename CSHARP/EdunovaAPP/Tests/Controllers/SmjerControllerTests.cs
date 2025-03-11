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
    /// Test klasa za kontroler SmjerController. Sadrži jedinicne testove za provjeru ispravnosti rada metoda.
    /// </summary>
    public class SmjerControllerTests
    {
        private readonly DbContextOptions<EdunovaContext> _options;
        private readonly EdunovaContext _context;
        private readonly Mock<IMapper> _mapperMock;
        private readonly SmjerController _controller;

        /// <summary>
        /// Inicijalizira instancu testa konfigurirajući in memory bazu, mapper i instancu kontrolera.
        /// </summary>
        public SmjerControllerTests()
        {
            _options = new DbContextOptionsBuilder<EdunovaContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_" + Guid.NewGuid().ToString())
                .Options;

            _context = new EdunovaContext(_options);
            _mapperMock = new Mock<IMapper>();
            _controller = new SmjerController(_context, _mapperMock.Object);
        }

        /// <summary>
        /// Testira metodu Get i provjerava vraća li ispravan rezultat s listom smjerova.
        /// </summary>
        [Fact]
        public void Get_ReturnsOkWithSmjerList()
        {
            // Arrange
            var smjerovi = new List<Smjer>
                {
                    new() { Sifra = 1, Naziv = "Test Smjer 1", Cijena = 100 },
                    new() { Sifra = 2, Naziv = "Test Smjer 2", Cijena = 200 }
                };

            var smjeroviDTO = new List<SmjerDTORead>
                {
                    new(1, "Test Smjer 1", 100, null, null),
                    new(2, "Test Smjer 2", 200, null, null)
                };

            _context.Smjerovi.AddRange(smjerovi);
            _context.SaveChanges();

            _mapperMock.Setup(m => m.Map<List<SmjerDTORead>>(It.IsAny<IEnumerable<Smjer>>()))
                .Returns(smjeroviDTO);

            // Act
            var result = _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedSmjerovi = Assert.IsType<List<SmjerDTORead>>(okResult.Value);
            Assert.Equal(2, returnedSmjerovi.Count);
        }

        /// <summary>
        /// Testira metodu GetBySifra za postojeći smjer i provjerava vraća li ispravan DTO.
        /// </summary>
        [Fact]
        public void GetBySifra_ExistingSmjer_ReturnsOkWithSmjer()
        {
            // Arrange
            var smjer = new Smjer { Sifra = 1, Naziv = "Test Smjer", Cijena = 100 };
            var smjerDTO = new SmjerDTOInsertUpdate("Test Smjer", 100, null, null);

            _context.Smjerovi.Add(smjer);
            _context.SaveChanges();

            _mapperMock.Setup(m => m.Map<SmjerDTOInsertUpdate>(It.IsAny<Smjer>()))
                .Returns(smjerDTO);

            // Act
            var result = _controller.GetBySifra(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedSmjer = Assert.IsType<SmjerDTOInsertUpdate>(okResult.Value);
            Assert.Equal("Test Smjer", returnedSmjer.Naziv);
        }

        /// <summary>
        /// Testira metodu GetBySifra za nepostojeći smjer i očekuje rezultat NotFound.
        /// </summary>
        [Fact]
        public void GetBySifra_NonExistingSmjer_ReturnsNotFound()
        {
            // Act
            var result = _controller.GetBySifra(999);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        /// <summary>
        /// Testira metodu Post za dodavanje novog smjera i provjerava vraća li status Created i ispravan DTO.
        /// </summary>
        [Fact]
        public void Post_ValidSmjer_ReturnsCreatedWithSmjer()
        {
            // Arrange
            var smjerDTO = new SmjerDTOInsertUpdate("New Smjer", 150, null, null);
            var smjer = new Smjer { Sifra = 1, Naziv = "New Smjer", Cijena = 150 };
            var smjerReadDTO = new SmjerDTORead(1, "New Smjer", 150, null, null);

            _mapperMock.Setup(m => m.Map<Smjer>(smjerDTO))
                .Returns(smjer);
            _mapperMock.Setup(m => m.Map<SmjerDTORead>(It.IsAny<Smjer>()))
                .Returns(smjerReadDTO);

            // Act
            var result = _controller.Post(smjerDTO);

            // Assert
            var createdResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status201Created, createdResult.StatusCode);
            var returnedSmjer = Assert.IsType<SmjerDTORead>(createdResult.Value);
            Assert.Equal("New Smjer", returnedSmjer.Naziv);
        }

        /// <summary>
        /// Testira metodu Put za ažuriranje postojećeg smjera i provjerava vraća li status OK s porukom uspjeha.
        /// </summary>
        [Fact]
        public void Put_ExistingSmjer_ReturnsOkWithSuccessMessage()
        {
            // Arrange
            // First create and save a Smjer
            var smjer = new Smjer { Sifra = 1, Naziv = "Original Smjer", Cijena = 100 };
            _context.Smjerovi.Add(smjer);
            _context.SaveChanges();

            // Create the DTO for updating
            var smjerDTO = new SmjerDTOInsertUpdate("Updated Smjer", 200, null, null);
            
            // Mock the mapper to properly update the entity
            _mapperMock.Setup(m => m.Map(It.IsAny<SmjerDTOInsertUpdate>(), It.IsAny<Smjer>()))
                .Callback<SmjerDTOInsertUpdate, Smjer>((src, dest) => {
                    dest.Naziv = src.Naziv;
                    dest.Cijena = src.Cijena;
                    dest.Vaucer = src.Vaucer;
                })
                .Returns(smjer);

            // Act
            var result = _controller.Put(1, smjerDTO);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Contains("Uspješno promjenjeno", okResult.Value.ToString());
        }

        /// <summary>
        /// Testira metodu Put za ažuriranje nepostojećeg smjera i očekuje rezultat NotFound.
        /// </summary>
        [Fact]
        public void Put_NonExistingSmjer_ReturnsNotFound()
        {
            // Arrange
            var smjerDTO = new SmjerDTOInsertUpdate("Updated Smjer", 200, null, null);

            // Act
            var result = _controller.Put(999, smjerDTO);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        /// <summary>
        /// Testira metodu Delete za brisanje postojećeg smjera i provjerava vraća li status OK s porukom uspjeha.
        /// </summary>
        [Fact]
        public void Delete_ExistingSmjer_ReturnsOkWithSuccessMessage()
        {
            // Arrange
            var smjer = new Smjer { Sifra = 1, Naziv = "Test Smjer", Cijena = 100 };

            _context.Smjerovi.Add(smjer);
            _context.SaveChanges();

            // Act
            var result = _controller.Delete(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Contains("Uspješno obrisano", okResult.Value.ToString());
        }

        /// <summary>
        /// Testira metodu Delete za brisanje nepostojećeg smjera i očekuje rezultat NotFound.
        /// </summary>
        [Fact]
        public void Delete_NonExistingSmjer_ReturnsNotFound()
        {
            // Act
            var result = _controller.Delete(999);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
