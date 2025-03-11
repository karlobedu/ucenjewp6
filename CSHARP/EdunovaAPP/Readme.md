<a name='assembly'></a>
# EdunovaAPP

## Contents

- [AutorizacijaController](#T-EdunovaAPP-Controllers-AutorizacijaController 'EdunovaAPP.Controllers.AutorizacijaController')
  - [#ctor(context)](#M-EdunovaAPP-Controllers-AutorizacijaController-#ctor-EdunovaAPP-Data-EdunovaContext- 'EdunovaAPP.Controllers.AutorizacijaController.#ctor(EdunovaAPP.Data.EdunovaContext)')
  - [_context](#F-EdunovaAPP-Controllers-AutorizacijaController-_context 'EdunovaAPP.Controllers.AutorizacijaController._context')
  - [GenerirajToken(operater)](#M-EdunovaAPP-Controllers-AutorizacijaController-GenerirajToken-EdunovaAPP-Models-DTO-OperaterDTO- 'EdunovaAPP.Controllers.AutorizacijaController.GenerirajToken(EdunovaAPP.Models.DTO.OperaterDTO)')
- [AutorizacijaControllerTests](#T-EdunovaAPP-Tests-Controllers-AutorizacijaControllerTests 'EdunovaAPP.Tests.Controllers.AutorizacijaControllerTests')
  - [#ctor()](#M-EdunovaAPP-Tests-Controllers-AutorizacijaControllerTests-#ctor 'EdunovaAPP.Tests.Controllers.AutorizacijaControllerTests.#ctor')
  - [GenerirajToken_InvalidEmail_ReturnsForbidden()](#M-EdunovaAPP-Tests-Controllers-AutorizacijaControllerTests-GenerirajToken_InvalidEmail_ReturnsForbidden 'EdunovaAPP.Tests.Controllers.AutorizacijaControllerTests.GenerirajToken_InvalidEmail_ReturnsForbidden')
  - [GenerirajToken_InvalidModel_ReturnsBadRequest()](#M-EdunovaAPP-Tests-Controllers-AutorizacijaControllerTests-GenerirajToken_InvalidModel_ReturnsBadRequest 'EdunovaAPP.Tests.Controllers.AutorizacijaControllerTests.GenerirajToken_InvalidModel_ReturnsBadRequest')
  - [GenerirajToken_InvalidPassword_ReturnsForbidden()](#M-EdunovaAPP-Tests-Controllers-AutorizacijaControllerTests-GenerirajToken_InvalidPassword_ReturnsForbidden 'EdunovaAPP.Tests.Controllers.AutorizacijaControllerTests.GenerirajToken_InvalidPassword_ReturnsForbidden')
  - [GenerirajToken_ValidCredentials_ReturnsOkWithToken()](#M-EdunovaAPP-Tests-Controllers-AutorizacijaControllerTests-GenerirajToken_ValidCredentials_ReturnsOkWithToken 'EdunovaAPP.Tests.Controllers.AutorizacijaControllerTests.GenerirajToken_ValidCredentials_ReturnsOkWithToken')
- [EdunovaContext](#T-EdunovaAPP-Data-EdunovaContext 'EdunovaAPP.Data.EdunovaContext')
  - [#ctor(opcije)](#M-EdunovaAPP-Data-EdunovaContext-#ctor-Microsoft-EntityFrameworkCore-DbContextOptions{EdunovaAPP-Data-EdunovaContext}- 'EdunovaAPP.Data.EdunovaContext.#ctor(Microsoft.EntityFrameworkCore.DbContextOptions{EdunovaAPP.Data.EdunovaContext})')
  - [Grupe](#P-EdunovaAPP-Data-EdunovaContext-Grupe 'EdunovaAPP.Data.EdunovaContext.Grupe')
  - [Operateri](#P-EdunovaAPP-Data-EdunovaContext-Operateri 'EdunovaAPP.Data.EdunovaContext.Operateri')
  - [Polaznici](#P-EdunovaAPP-Data-EdunovaContext-Polaznici 'EdunovaAPP.Data.EdunovaContext.Polaznici')
  - [Smjerovi](#P-EdunovaAPP-Data-EdunovaContext-Smjerovi 'EdunovaAPP.Data.EdunovaContext.Smjerovi')
  - [OnModelCreating(modelBuilder)](#M-EdunovaAPP-Data-EdunovaContext-OnModelCreating-Microsoft-EntityFrameworkCore-ModelBuilder- 'EdunovaAPP.Data.EdunovaContext.OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder)')
- [EdunovaController](#T-EdunovaAPP-Controllers-EdunovaController 'EdunovaAPP.Controllers.EdunovaController')
  - [#ctor(context,mapper)](#M-EdunovaAPP-Controllers-EdunovaController-#ctor-EdunovaAPP-Data-EdunovaContext,AutoMapper-IMapper- 'EdunovaAPP.Controllers.EdunovaController.#ctor(EdunovaAPP.Data.EdunovaContext,AutoMapper.IMapper)')
  - [_context](#F-EdunovaAPP-Controllers-EdunovaController-_context 'EdunovaAPP.Controllers.EdunovaController._context')
  - [_mapper](#F-EdunovaAPP-Controllers-EdunovaController-_mapper 'EdunovaAPP.Controllers.EdunovaController._mapper')
- [EdunovaExtensions](#T-EdunovaAPP-Extensions-EdunovaExtensions 'EdunovaAPP.Extensions.EdunovaExtensions')
  - [AddEdunovaCORS(Services)](#M-EdunovaAPP-Extensions-EdunovaExtensions-AddEdunovaCORS-Microsoft-Extensions-DependencyInjection-IServiceCollection- 'EdunovaAPP.Extensions.EdunovaExtensions.AddEdunovaCORS(Microsoft.Extensions.DependencyInjection.IServiceCollection)')
  - [AddEdunovaSecurity(Services)](#M-EdunovaAPP-Extensions-EdunovaExtensions-AddEdunovaSecurity-Microsoft-Extensions-DependencyInjection-IServiceCollection- 'EdunovaAPP.Extensions.EdunovaExtensions.AddEdunovaSecurity(Microsoft.Extensions.DependencyInjection.IServiceCollection)')
  - [AddEdunovaSwaggerGen(Services)](#M-EdunovaAPP-Extensions-EdunovaExtensions-AddEdunovaSwaggerGen-Microsoft-Extensions-DependencyInjection-IServiceCollection- 'EdunovaAPP.Extensions.EdunovaExtensions.AddEdunovaSwaggerGen(Microsoft.Extensions.DependencyInjection.IServiceCollection)')
- [EdunovaMappingProfile](#T-EdunovaAPP-Mapping-EdunovaMappingProfile 'EdunovaAPP.Mapping.EdunovaMappingProfile')
  - [#ctor()](#M-EdunovaAPP-Mapping-EdunovaMappingProfile-#ctor 'EdunovaAPP.Mapping.EdunovaMappingProfile.#ctor')
  - [PutanjaDatoteke(e)](#M-EdunovaAPP-Mapping-EdunovaMappingProfile-PutanjaDatoteke-EdunovaAPP-Models-Polaznik- 'EdunovaAPP.Mapping.EdunovaMappingProfile.PutanjaDatoteke(EdunovaAPP.Models.Polaznik)')
- [Entitet](#T-EdunovaAPP-Models-Entitet 'EdunovaAPP.Models.Entitet')
  - [Sifra](#P-EdunovaAPP-Models-Entitet-Sifra 'EdunovaAPP.Models.Entitet.Sifra')
- [GrafGrupaDTO](#T-EdunovaAPP-Models-DTO-GrafGrupaDTO 'EdunovaAPP.Models.DTO.GrafGrupaDTO')
  - [#ctor()](#M-EdunovaAPP-Models-DTO-GrafGrupaDTO-#ctor-System-String,System-Int32- 'EdunovaAPP.Models.DTO.GrafGrupaDTO.#ctor(System.String,System.Int32)')
- [Grupa](#T-EdunovaAPP-Models-Grupa 'EdunovaAPP.Models.Grupa')
  - [MaksimalnoPolaznika](#P-EdunovaAPP-Models-Grupa-MaksimalnoPolaznika 'EdunovaAPP.Models.Grupa.MaksimalnoPolaznika')
  - [Naziv](#P-EdunovaAPP-Models-Grupa-Naziv 'EdunovaAPP.Models.Grupa.Naziv')
  - [Polaznici](#P-EdunovaAPP-Models-Grupa-Polaznici 'EdunovaAPP.Models.Grupa.Polaznici')
  - [Predavac](#P-EdunovaAPP-Models-Grupa-Predavac 'EdunovaAPP.Models.Grupa.Predavac')
  - [Smjer](#P-EdunovaAPP-Models-Grupa-Smjer 'EdunovaAPP.Models.Grupa.Smjer')
- [GrupaController](#T-EdunovaAPP-Controllers-GrupaController 'EdunovaAPP.Controllers.GrupaController')
  - [#ctor(context,mapper)](#M-EdunovaAPP-Controllers-GrupaController-#ctor-EdunovaAPP-Data-EdunovaContext,AutoMapper-IMapper- 'EdunovaAPP.Controllers.GrupaController.#ctor(EdunovaAPP.Data.EdunovaContext,AutoMapper.IMapper)')
  - [Delete(sifra)](#M-EdunovaAPP-Controllers-GrupaController-Delete-System-Int32- 'EdunovaAPP.Controllers.GrupaController.Delete(System.Int32)')
  - [DodajPolaznika(sifra,polaznikSifra)](#M-EdunovaAPP-Controllers-GrupaController-DodajPolaznika-System-Int32,System-Int32- 'EdunovaAPP.Controllers.GrupaController.DodajPolaznika(System.Int32,System.Int32)')
  - [Get()](#M-EdunovaAPP-Controllers-GrupaController-Get 'EdunovaAPP.Controllers.GrupaController.Get')
  - [GetBySifra(sifra)](#M-EdunovaAPP-Controllers-GrupaController-GetBySifra-System-Int32- 'EdunovaAPP.Controllers.GrupaController.GetBySifra(System.Int32)')
  - [GetPolaznici(sifraGrupe)](#M-EdunovaAPP-Controllers-GrupaController-GetPolaznici-System-Int32- 'EdunovaAPP.Controllers.GrupaController.GetPolaznici(System.Int32)')
  - [GrafGrupe()](#M-EdunovaAPP-Controllers-GrupaController-GrafGrupe 'EdunovaAPP.Controllers.GrupaController.GrafGrupe')
  - [ObrisiPolaznika(sifra,polaznikSifra)](#M-EdunovaAPP-Controllers-GrupaController-ObrisiPolaznika-System-Int32,System-Int32- 'EdunovaAPP.Controllers.GrupaController.ObrisiPolaznika(System.Int32,System.Int32)')
  - [Post(dto)](#M-EdunovaAPP-Controllers-GrupaController-Post-EdunovaAPP-Models-DTO-GrupaDTOInsertUpdate- 'EdunovaAPP.Controllers.GrupaController.Post(EdunovaAPP.Models.DTO.GrupaDTOInsertUpdate)')
  - [Put(sifra,dto)](#M-EdunovaAPP-Controllers-GrupaController-Put-System-Int32,EdunovaAPP-Models-DTO-GrupaDTOInsertUpdate- 'EdunovaAPP.Controllers.GrupaController.Put(System.Int32,EdunovaAPP.Models.DTO.GrupaDTOInsertUpdate)')
- [GrupaControllerTests](#T-EdunovaAPP-Tests-Controllers-GrupaControllerTests 'EdunovaAPP.Tests.Controllers.GrupaControllerTests')
  - [#ctor()](#M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-#ctor 'EdunovaAPP.Tests.Controllers.GrupaControllerTests.#ctor')
  - [Delete_ExistingGrupa_ReturnsOkWithSuccessMessage()](#M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-Delete_ExistingGrupa_ReturnsOkWithSuccessMessage 'EdunovaAPP.Tests.Controllers.GrupaControllerTests.Delete_ExistingGrupa_ReturnsOkWithSuccessMessage')
  - [Delete_NonExistingGrupa_ReturnsNotFound()](#M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-Delete_NonExistingGrupa_ReturnsNotFound 'EdunovaAPP.Tests.Controllers.GrupaControllerTests.Delete_NonExistingGrupa_ReturnsNotFound')
  - [DodajPolaznika_NonExistingGrupa_ReturnsBadRequest()](#M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-DodajPolaznika_NonExistingGrupa_ReturnsBadRequest 'EdunovaAPP.Tests.Controllers.GrupaControllerTests.DodajPolaznika_NonExistingGrupa_ReturnsBadRequest')
  - [DodajPolaznika_NonExistingPolaznik_ReturnsBadRequest()](#M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-DodajPolaznika_NonExistingPolaznik_ReturnsBadRequest 'EdunovaAPP.Tests.Controllers.GrupaControllerTests.DodajPolaznika_NonExistingPolaznik_ReturnsBadRequest')
  - [DodajPolaznika_ValidParameters_ReturnsOkWithSuccessMessage()](#M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-DodajPolaznika_ValidParameters_ReturnsOkWithSuccessMessage 'EdunovaAPP.Tests.Controllers.GrupaControllerTests.DodajPolaznika_ValidParameters_ReturnsOkWithSuccessMessage')
  - [GetBySifra_ExistingGrupa_ReturnsOkWithGrupa()](#M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-GetBySifra_ExistingGrupa_ReturnsOkWithGrupa 'EdunovaAPP.Tests.Controllers.GrupaControllerTests.GetBySifra_ExistingGrupa_ReturnsOkWithGrupa')
  - [GetBySifra_NonExistingGrupa_ReturnsNotFound()](#M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-GetBySifra_NonExistingGrupa_ReturnsNotFound 'EdunovaAPP.Tests.Controllers.GrupaControllerTests.GetBySifra_NonExistingGrupa_ReturnsNotFound')
  - [GetPolaznici_ExistingGrupa_ReturnsOkWithPolaznici()](#M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-GetPolaznici_ExistingGrupa_ReturnsOkWithPolaznici 'EdunovaAPP.Tests.Controllers.GrupaControllerTests.GetPolaznici_ExistingGrupa_ReturnsOkWithPolaznici')
  - [GetPolaznici_NonExistingGrupa_ReturnsBadRequest()](#M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-GetPolaznici_NonExistingGrupa_ReturnsBadRequest 'EdunovaAPP.Tests.Controllers.GrupaControllerTests.GetPolaznici_NonExistingGrupa_ReturnsBadRequest')
  - [Get_ReturnsOkWithGrupaList()](#M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-Get_ReturnsOkWithGrupaList 'EdunovaAPP.Tests.Controllers.GrupaControllerTests.Get_ReturnsOkWithGrupaList')
  - [GrafGrupe_ReturnsOkWithGrafGrupaList()](#M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-GrafGrupe_ReturnsOkWithGrafGrupaList 'EdunovaAPP.Tests.Controllers.GrupaControllerTests.GrafGrupe_ReturnsOkWithGrafGrupaList')
  - [ObrisiPolaznika_ValidParameters_ReturnsOkWithSuccessMessage()](#M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-ObrisiPolaznika_ValidParameters_ReturnsOkWithSuccessMessage 'EdunovaAPP.Tests.Controllers.GrupaControllerTests.ObrisiPolaznika_ValidParameters_ReturnsOkWithSuccessMessage')
  - [Post_NonExistingSmjer_ReturnsNotFound()](#M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-Post_NonExistingSmjer_ReturnsNotFound 'EdunovaAPP.Tests.Controllers.GrupaControllerTests.Post_NonExistingSmjer_ReturnsNotFound')
  - [Post_ValidGrupa_ReturnsCreatedWithGrupa()](#M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-Post_ValidGrupa_ReturnsCreatedWithGrupa 'EdunovaAPP.Tests.Controllers.GrupaControllerTests.Post_ValidGrupa_ReturnsCreatedWithGrupa')
  - [Put_ExistingGrupa_ReturnsOkWithSuccessMessage()](#M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-Put_ExistingGrupa_ReturnsOkWithSuccessMessage 'EdunovaAPP.Tests.Controllers.GrupaControllerTests.Put_ExistingGrupa_ReturnsOkWithSuccessMessage')
  - [Put_NonExistingGrupa_ReturnsNotFound()](#M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-Put_NonExistingGrupa_ReturnsNotFound 'EdunovaAPP.Tests.Controllers.GrupaControllerTests.Put_NonExistingGrupa_ReturnsNotFound')
- [GrupaDTOInsertUpdate](#T-EdunovaAPP-Models-DTO-GrupaDTOInsertUpdate 'EdunovaAPP.Models.DTO.GrupaDTOInsertUpdate')
  - [#ctor(Naziv,SmjerSifra,Predavac,MaksimalnoPolaznika)](#M-EdunovaAPP-Models-DTO-GrupaDTOInsertUpdate-#ctor-System-String,System-Nullable{System-Int32},System-String,System-Int32- 'EdunovaAPP.Models.DTO.GrupaDTOInsertUpdate.#ctor(System.String,System.Nullable{System.Int32},System.String,System.Int32)')
  - [MaksimalnoPolaznika](#P-EdunovaAPP-Models-DTO-GrupaDTOInsertUpdate-MaksimalnoPolaznika 'EdunovaAPP.Models.DTO.GrupaDTOInsertUpdate.MaksimalnoPolaznika')
  - [Naziv](#P-EdunovaAPP-Models-DTO-GrupaDTOInsertUpdate-Naziv 'EdunovaAPP.Models.DTO.GrupaDTOInsertUpdate.Naziv')
  - [Predavac](#P-EdunovaAPP-Models-DTO-GrupaDTOInsertUpdate-Predavac 'EdunovaAPP.Models.DTO.GrupaDTOInsertUpdate.Predavac')
  - [SmjerSifra](#P-EdunovaAPP-Models-DTO-GrupaDTOInsertUpdate-SmjerSifra 'EdunovaAPP.Models.DTO.GrupaDTOInsertUpdate.SmjerSifra')
- [GrupaDTORead](#T-EdunovaAPP-Models-DTO-GrupaDTORead 'EdunovaAPP.Models.DTO.GrupaDTORead')
  - [#ctor(Sifra,Naziv,SmjerNaziv,Predavac,MaksimalnoPolaznika)](#M-EdunovaAPP-Models-DTO-GrupaDTORead-#ctor-System-Int32,System-String,System-String,System-String,System-Nullable{System-Int32}- 'EdunovaAPP.Models.DTO.GrupaDTORead.#ctor(System.Int32,System.String,System.String,System.String,System.Nullable{System.Int32})')
  - [MaksimalnoPolaznika](#P-EdunovaAPP-Models-DTO-GrupaDTORead-MaksimalnoPolaznika 'EdunovaAPP.Models.DTO.GrupaDTORead.MaksimalnoPolaznika')
  - [Naziv](#P-EdunovaAPP-Models-DTO-GrupaDTORead-Naziv 'EdunovaAPP.Models.DTO.GrupaDTORead.Naziv')
  - [Predavac](#P-EdunovaAPP-Models-DTO-GrupaDTORead-Predavac 'EdunovaAPP.Models.DTO.GrupaDTORead.Predavac')
  - [Sifra](#P-EdunovaAPP-Models-DTO-GrupaDTORead-Sifra 'EdunovaAPP.Models.DTO.GrupaDTORead.Sifra')
  - [SmjerNaziv](#P-EdunovaAPP-Models-DTO-GrupaDTORead-SmjerNaziv 'EdunovaAPP.Models.DTO.GrupaDTORead.SmjerNaziv')
- [Operater](#T-EdunovaAPP-Models-Operater 'EdunovaAPP.Models.Operater')
  - [Email](#P-EdunovaAPP-Models-Operater-Email 'EdunovaAPP.Models.Operater.Email')
  - [Lozinka](#P-EdunovaAPP-Models-Operater-Lozinka 'EdunovaAPP.Models.Operater.Lozinka')
- [OperaterDTO](#T-EdunovaAPP-Models-DTO-OperaterDTO 'EdunovaAPP.Models.DTO.OperaterDTO')
  - [#ctor(Email,Password)](#M-EdunovaAPP-Models-DTO-OperaterDTO-#ctor-System-String,System-String- 'EdunovaAPP.Models.DTO.OperaterDTO.#ctor(System.String,System.String)')
  - [Email](#P-EdunovaAPP-Models-DTO-OperaterDTO-Email 'EdunovaAPP.Models.DTO.OperaterDTO.Email')
  - [Password](#P-EdunovaAPP-Models-DTO-OperaterDTO-Password 'EdunovaAPP.Models.DTO.OperaterDTO.Password')
- [PocetnaController](#T-EdunovaAPP-Controllers-PocetnaController 'EdunovaAPP.Controllers.PocetnaController')
  - [#ctor(_context)](#M-EdunovaAPP-Controllers-PocetnaController-#ctor-EdunovaAPP-Data-EdunovaContext- 'EdunovaAPP.Controllers.PocetnaController.#ctor(EdunovaAPP.Data.EdunovaContext)')
  - [DostupniSmjerovi()](#M-EdunovaAPP-Controllers-PocetnaController-DostupniSmjerovi 'EdunovaAPP.Controllers.PocetnaController.DostupniSmjerovi')
  - [UkupnoPolaznika()](#M-EdunovaAPP-Controllers-PocetnaController-UkupnoPolaznika 'EdunovaAPP.Controllers.PocetnaController.UkupnoPolaznika')
- [PocetnaControllerTests](#T-EdunovaAPP-Tests-Controllers-PocetnaControllerTests 'EdunovaAPP.Tests.Controllers.PocetnaControllerTests')
  - [#ctor()](#M-EdunovaAPP-Tests-Controllers-PocetnaControllerTests-#ctor 'EdunovaAPP.Tests.Controllers.PocetnaControllerTests.#ctor')
  - [DostupniSmjerovi_DatabaseError_ReturnsBadRequest()](#M-EdunovaAPP-Tests-Controllers-PocetnaControllerTests-DostupniSmjerovi_DatabaseError_ReturnsBadRequest 'EdunovaAPP.Tests.Controllers.PocetnaControllerTests.DostupniSmjerovi_DatabaseError_ReturnsBadRequest')
  - [DostupniSmjerovi_EmptyDatabase_ReturnsEmptyList()](#M-EdunovaAPP-Tests-Controllers-PocetnaControllerTests-DostupniSmjerovi_EmptyDatabase_ReturnsEmptyList 'EdunovaAPP.Tests.Controllers.PocetnaControllerTests.DostupniSmjerovi_EmptyDatabase_ReturnsEmptyList')
  - [DostupniSmjerovi_ReturnsOkWithSmjerList()](#M-EdunovaAPP-Tests-Controllers-PocetnaControllerTests-DostupniSmjerovi_ReturnsOkWithSmjerList 'EdunovaAPP.Tests.Controllers.PocetnaControllerTests.DostupniSmjerovi_ReturnsOkWithSmjerList')
  - [UkupnoPolaznika_DatabaseError_ReturnsBadRequest()](#M-EdunovaAPP-Tests-Controllers-PocetnaControllerTests-UkupnoPolaznika_DatabaseError_ReturnsBadRequest 'EdunovaAPP.Tests.Controllers.PocetnaControllerTests.UkupnoPolaznika_DatabaseError_ReturnsBadRequest')
  - [UkupnoPolaznika_EmptyDatabase_ReturnsZero()](#M-EdunovaAPP-Tests-Controllers-PocetnaControllerTests-UkupnoPolaznika_EmptyDatabase_ReturnsZero 'EdunovaAPP.Tests.Controllers.PocetnaControllerTests.UkupnoPolaznika_EmptyDatabase_ReturnsZero')
  - [UkupnoPolaznika_ReturnsOkWithCount()](#M-EdunovaAPP-Tests-Controllers-PocetnaControllerTests-UkupnoPolaznika_ReturnsOkWithCount 'EdunovaAPP.Tests.Controllers.PocetnaControllerTests.UkupnoPolaznika_ReturnsOkWithCount')
- [Polaznik](#T-EdunovaAPP-Models-Polaznik 'EdunovaAPP.Models.Polaznik')
  - [Email](#P-EdunovaAPP-Models-Polaznik-Email 'EdunovaAPP.Models.Polaznik.Email')
  - [Grupe](#P-EdunovaAPP-Models-Polaznik-Grupe 'EdunovaAPP.Models.Polaznik.Grupe')
  - [Ime](#P-EdunovaAPP-Models-Polaznik-Ime 'EdunovaAPP.Models.Polaznik.Ime')
  - [Oib](#P-EdunovaAPP-Models-Polaznik-Oib 'EdunovaAPP.Models.Polaznik.Oib')
  - [Prezime](#P-EdunovaAPP-Models-Polaznik-Prezime 'EdunovaAPP.Models.Polaznik.Prezime')
- [PolaznikController](#T-EdunovaAPP-Controllers-PolaznikController 'EdunovaAPP.Controllers.PolaznikController')
  - [#ctor(context,mapper)](#M-EdunovaAPP-Controllers-PolaznikController-#ctor-EdunovaAPP-Data-EdunovaContext,AutoMapper-IMapper- 'EdunovaAPP.Controllers.PolaznikController.#ctor(EdunovaAPP.Data.EdunovaContext,AutoMapper.IMapper)')
  - [Delete(sifra)](#M-EdunovaAPP-Controllers-PolaznikController-Delete-System-Int32- 'EdunovaAPP.Controllers.PolaznikController.Delete(System.Int32)')
  - [Generiraj(broj)](#M-EdunovaAPP-Controllers-PolaznikController-Generiraj-System-Int32- 'EdunovaAPP.Controllers.PolaznikController.Generiraj(System.Int32)')
  - [Get()](#M-EdunovaAPP-Controllers-PolaznikController-Get 'EdunovaAPP.Controllers.PolaznikController.Get')
  - [GetBySifra(sifra)](#M-EdunovaAPP-Controllers-PolaznikController-GetBySifra-System-Int32- 'EdunovaAPP.Controllers.PolaznikController.GetBySifra(System.Int32)')
  - [Post(dto)](#M-EdunovaAPP-Controllers-PolaznikController-Post-EdunovaAPP-Models-DTO-PolaznikDTOInsertUpdate- 'EdunovaAPP.Controllers.PolaznikController.Post(EdunovaAPP.Models.DTO.PolaznikDTOInsertUpdate)')
  - [PostaviSliku(sifra,slika)](#M-EdunovaAPP-Controllers-PolaznikController-PostaviSliku-System-Int32,EdunovaAPP-Models-DTO-SlikaDTO- 'EdunovaAPP.Controllers.PolaznikController.PostaviSliku(System.Int32,EdunovaAPP.Models.DTO.SlikaDTO)')
  - [Put(sifra,dto)](#M-EdunovaAPP-Controllers-PolaznikController-Put-System-Int32,EdunovaAPP-Models-DTO-PolaznikDTOInsertUpdate- 'EdunovaAPP.Controllers.PolaznikController.Put(System.Int32,EdunovaAPP.Models.DTO.PolaznikDTOInsertUpdate)')
  - [TraziPolaznik(uvjet)](#M-EdunovaAPP-Controllers-PolaznikController-TraziPolaznik-System-String- 'EdunovaAPP.Controllers.PolaznikController.TraziPolaznik(System.String)')
  - [TraziPolaznikStranicenje(stranica,uvjet)](#M-EdunovaAPP-Controllers-PolaznikController-TraziPolaznikStranicenje-System-Int32,System-String- 'EdunovaAPP.Controllers.PolaznikController.TraziPolaznikStranicenje(System.Int32,System.String)')
- [PolaznikControllerTests](#T-EdunovaAPP-Tests-Controllers-PolaznikControllerTests 'EdunovaAPP.Tests.Controllers.PolaznikControllerTests')
  - [#ctor()](#M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-#ctor 'EdunovaAPP.Tests.Controllers.PolaznikControllerTests.#ctor')
  - [Delete_ExistingPolaznik_ReturnsOkWithSuccessMessage()](#M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-Delete_ExistingPolaznik_ReturnsOkWithSuccessMessage 'EdunovaAPP.Tests.Controllers.PolaznikControllerTests.Delete_ExistingPolaznik_ReturnsOkWithSuccessMessage')
  - [Delete_NonExistingPolaznik_ReturnsNotFound()](#M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-Delete_NonExistingPolaznik_ReturnsNotFound 'EdunovaAPP.Tests.Controllers.PolaznikControllerTests.Delete_NonExistingPolaznik_ReturnsNotFound')
  - [GetBySifra_ExistingPolaznik_ReturnsOkWithPolaznik()](#M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-GetBySifra_ExistingPolaznik_ReturnsOkWithPolaznik 'EdunovaAPP.Tests.Controllers.PolaznikControllerTests.GetBySifra_ExistingPolaznik_ReturnsOkWithPolaznik')
  - [GetBySifra_NonExistingPolaznik_ReturnsNotFound()](#M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-GetBySifra_NonExistingPolaznik_ReturnsNotFound 'EdunovaAPP.Tests.Controllers.PolaznikControllerTests.GetBySifra_NonExistingPolaznik_ReturnsNotFound')
  - [Get_ReturnsOkWithPolaznikList()](#M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-Get_ReturnsOkWithPolaznikList 'EdunovaAPP.Tests.Controllers.PolaznikControllerTests.Get_ReturnsOkWithPolaznikList')
  - [Post_ValidPolaznik_ReturnsCreatedWithPolaznik()](#M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-Post_ValidPolaznik_ReturnsCreatedWithPolaznik 'EdunovaAPP.Tests.Controllers.PolaznikControllerTests.Post_ValidPolaznik_ReturnsCreatedWithPolaznik')
  - [Put_ExistingPolaznik_ReturnsOkWithSuccessMessage()](#M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-Put_ExistingPolaznik_ReturnsOkWithSuccessMessage 'EdunovaAPP.Tests.Controllers.PolaznikControllerTests.Put_ExistingPolaznik_ReturnsOkWithSuccessMessage')
  - [Put_NonExistingPolaznik_ReturnsNotFound()](#M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-Put_NonExistingPolaznik_ReturnsNotFound 'EdunovaAPP.Tests.Controllers.PolaznikControllerTests.Put_NonExistingPolaznik_ReturnsNotFound')
  - [TraziPolaznikStranicenje_ValidParameters_ReturnsPagedResults()](#M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-TraziPolaznikStranicenje_ValidParameters_ReturnsPagedResults 'EdunovaAPP.Tests.Controllers.PolaznikControllerTests.TraziPolaznikStranicenje_ValidParameters_ReturnsPagedResults')
  - [TraziPolaznik_ShortSearchTerm_ReturnsBadRequest()](#M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-TraziPolaznik_ShortSearchTerm_ReturnsBadRequest 'EdunovaAPP.Tests.Controllers.PolaznikControllerTests.TraziPolaznik_ShortSearchTerm_ReturnsBadRequest')
  - [TraziPolaznik_ValidSearchTerm_ReturnsMatchingPolaznici()](#M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-TraziPolaznik_ValidSearchTerm_ReturnsMatchingPolaznici 'EdunovaAPP.Tests.Controllers.PolaznikControllerTests.TraziPolaznik_ValidSearchTerm_ReturnsMatchingPolaznici')
- [PolaznikDTOInsertUpdate](#T-EdunovaAPP-Models-DTO-PolaznikDTOInsertUpdate 'EdunovaAPP.Models.DTO.PolaznikDTOInsertUpdate')
  - [#ctor(Ime,Prezime,Email,Oib)](#M-EdunovaAPP-Models-DTO-PolaznikDTOInsertUpdate-#ctor-System-String,System-String,System-String,System-String- 'EdunovaAPP.Models.DTO.PolaznikDTOInsertUpdate.#ctor(System.String,System.String,System.String,System.String)')
  - [Email](#P-EdunovaAPP-Models-DTO-PolaznikDTOInsertUpdate-Email 'EdunovaAPP.Models.DTO.PolaznikDTOInsertUpdate.Email')
  - [Ime](#P-EdunovaAPP-Models-DTO-PolaznikDTOInsertUpdate-Ime 'EdunovaAPP.Models.DTO.PolaznikDTOInsertUpdate.Ime')
  - [Oib](#P-EdunovaAPP-Models-DTO-PolaznikDTOInsertUpdate-Oib 'EdunovaAPP.Models.DTO.PolaznikDTOInsertUpdate.Oib')
  - [Prezime](#P-EdunovaAPP-Models-DTO-PolaznikDTOInsertUpdate-Prezime 'EdunovaAPP.Models.DTO.PolaznikDTOInsertUpdate.Prezime')
- [PolaznikDTORead](#T-EdunovaAPP-Models-DTO-PolaznikDTORead 'EdunovaAPP.Models.DTO.PolaznikDTORead')
  - [#ctor(Sifra,Ime,Prezime,Email,Oib,Slika)](#M-EdunovaAPP-Models-DTO-PolaznikDTORead-#ctor-System-Nullable{System-Int32},System-String,System-String,System-String,System-String,System-String- 'EdunovaAPP.Models.DTO.PolaznikDTORead.#ctor(System.Nullable{System.Int32},System.String,System.String,System.String,System.String,System.String)')
  - [Email](#P-EdunovaAPP-Models-DTO-PolaznikDTORead-Email 'EdunovaAPP.Models.DTO.PolaznikDTORead.Email')
  - [Ime](#P-EdunovaAPP-Models-DTO-PolaznikDTORead-Ime 'EdunovaAPP.Models.DTO.PolaznikDTORead.Ime')
  - [Oib](#P-EdunovaAPP-Models-DTO-PolaznikDTORead-Oib 'EdunovaAPP.Models.DTO.PolaznikDTORead.Oib')
  - [Prezime](#P-EdunovaAPP-Models-DTO-PolaznikDTORead-Prezime 'EdunovaAPP.Models.DTO.PolaznikDTORead.Prezime')
  - [Sifra](#P-EdunovaAPP-Models-DTO-PolaznikDTORead-Sifra 'EdunovaAPP.Models.DTO.PolaznikDTORead.Sifra')
  - [Slika](#P-EdunovaAPP-Models-DTO-PolaznikDTORead-Slika 'EdunovaAPP.Models.DTO.PolaznikDTORead.Slika')
- [SlikaDTO](#T-EdunovaAPP-Models-DTO-SlikaDTO 'EdunovaAPP.Models.DTO.SlikaDTO')
  - [#ctor(Base64)](#M-EdunovaAPP-Models-DTO-SlikaDTO-#ctor-System-String- 'EdunovaAPP.Models.DTO.SlikaDTO.#ctor(System.String)')
  - [Base64](#P-EdunovaAPP-Models-DTO-SlikaDTO-Base64 'EdunovaAPP.Models.DTO.SlikaDTO.Base64')
- [Smjer](#T-EdunovaAPP-Models-Smjer 'EdunovaAPP.Models.Smjer')
  - [Cijena](#P-EdunovaAPP-Models-Smjer-Cijena 'EdunovaAPP.Models.Smjer.Cijena')
  - [IzvodiSeOd](#P-EdunovaAPP-Models-Smjer-IzvodiSeOd 'EdunovaAPP.Models.Smjer.IzvodiSeOd')
  - [Naziv](#P-EdunovaAPP-Models-Smjer-Naziv 'EdunovaAPP.Models.Smjer.Naziv')
  - [Vaucer](#P-EdunovaAPP-Models-Smjer-Vaucer 'EdunovaAPP.Models.Smjer.Vaucer')
- [SmjerController](#T-EdunovaAPP-Controllers-SmjerController 'EdunovaAPP.Controllers.SmjerController')
  - [#ctor(context,mapper)](#M-EdunovaAPP-Controllers-SmjerController-#ctor-EdunovaAPP-Data-EdunovaContext,AutoMapper-IMapper- 'EdunovaAPP.Controllers.SmjerController.#ctor(EdunovaAPP.Data.EdunovaContext,AutoMapper.IMapper)')
  - [Delete(sifra)](#M-EdunovaAPP-Controllers-SmjerController-Delete-System-Int32- 'EdunovaAPP.Controllers.SmjerController.Delete(System.Int32)')
  - [Get()](#M-EdunovaAPP-Controllers-SmjerController-Get 'EdunovaAPP.Controllers.SmjerController.Get')
  - [GetBySifra(sifra)](#M-EdunovaAPP-Controllers-SmjerController-GetBySifra-System-Int32- 'EdunovaAPP.Controllers.SmjerController.GetBySifra(System.Int32)')
  - [Post(dto)](#M-EdunovaAPP-Controllers-SmjerController-Post-EdunovaAPP-Models-DTO-SmjerDTOInsertUpdate- 'EdunovaAPP.Controllers.SmjerController.Post(EdunovaAPP.Models.DTO.SmjerDTOInsertUpdate)')
  - [Put(sifra,dto)](#M-EdunovaAPP-Controllers-SmjerController-Put-System-Int32,EdunovaAPP-Models-DTO-SmjerDTOInsertUpdate- 'EdunovaAPP.Controllers.SmjerController.Put(System.Int32,EdunovaAPP.Models.DTO.SmjerDTOInsertUpdate)')
- [SmjerControllerTests](#T-EdunovaAPP-Tests-Controllers-SmjerControllerTests 'EdunovaAPP.Tests.Controllers.SmjerControllerTests')
  - [#ctor()](#M-EdunovaAPP-Tests-Controllers-SmjerControllerTests-#ctor 'EdunovaAPP.Tests.Controllers.SmjerControllerTests.#ctor')
  - [Delete_ExistingSmjer_ReturnsOkWithSuccessMessage()](#M-EdunovaAPP-Tests-Controllers-SmjerControllerTests-Delete_ExistingSmjer_ReturnsOkWithSuccessMessage 'EdunovaAPP.Tests.Controllers.SmjerControllerTests.Delete_ExistingSmjer_ReturnsOkWithSuccessMessage')
  - [Delete_NonExistingSmjer_ReturnsNotFound()](#M-EdunovaAPP-Tests-Controllers-SmjerControllerTests-Delete_NonExistingSmjer_ReturnsNotFound 'EdunovaAPP.Tests.Controllers.SmjerControllerTests.Delete_NonExistingSmjer_ReturnsNotFound')
  - [GetBySifra_ExistingSmjer_ReturnsOkWithSmjer()](#M-EdunovaAPP-Tests-Controllers-SmjerControllerTests-GetBySifra_ExistingSmjer_ReturnsOkWithSmjer 'EdunovaAPP.Tests.Controllers.SmjerControllerTests.GetBySifra_ExistingSmjer_ReturnsOkWithSmjer')
  - [GetBySifra_NonExistingSmjer_ReturnsNotFound()](#M-EdunovaAPP-Tests-Controllers-SmjerControllerTests-GetBySifra_NonExistingSmjer_ReturnsNotFound 'EdunovaAPP.Tests.Controllers.SmjerControllerTests.GetBySifra_NonExistingSmjer_ReturnsNotFound')
  - [Get_ReturnsOkWithSmjerList()](#M-EdunovaAPP-Tests-Controllers-SmjerControllerTests-Get_ReturnsOkWithSmjerList 'EdunovaAPP.Tests.Controllers.SmjerControllerTests.Get_ReturnsOkWithSmjerList')
  - [Post_ValidSmjer_ReturnsCreatedWithSmjer()](#M-EdunovaAPP-Tests-Controllers-SmjerControllerTests-Post_ValidSmjer_ReturnsCreatedWithSmjer 'EdunovaAPP.Tests.Controllers.SmjerControllerTests.Post_ValidSmjer_ReturnsCreatedWithSmjer')
  - [Put_ExistingSmjer_ReturnsOkWithSuccessMessage()](#M-EdunovaAPP-Tests-Controllers-SmjerControllerTests-Put_ExistingSmjer_ReturnsOkWithSuccessMessage 'EdunovaAPP.Tests.Controllers.SmjerControllerTests.Put_ExistingSmjer_ReturnsOkWithSuccessMessage')
  - [Put_NonExistingSmjer_ReturnsNotFound()](#M-EdunovaAPP-Tests-Controllers-SmjerControllerTests-Put_NonExistingSmjer_ReturnsNotFound 'EdunovaAPP.Tests.Controllers.SmjerControllerTests.Put_NonExistingSmjer_ReturnsNotFound')
- [SmjerDTOInsertUpdate](#T-EdunovaAPP-Models-DTO-SmjerDTOInsertUpdate 'EdunovaAPP.Models.DTO.SmjerDTOInsertUpdate')
  - [#ctor(Naziv,Cijena,IzvodiSeOd,Vaucer)](#M-EdunovaAPP-Models-DTO-SmjerDTOInsertUpdate-#ctor-System-String,System-Nullable{System-Decimal},System-Nullable{System-DateTime},System-Nullable{System-Boolean}- 'EdunovaAPP.Models.DTO.SmjerDTOInsertUpdate.#ctor(System.String,System.Nullable{System.Decimal},System.Nullable{System.DateTime},System.Nullable{System.Boolean})')
  - [Cijena](#P-EdunovaAPP-Models-DTO-SmjerDTOInsertUpdate-Cijena 'EdunovaAPP.Models.DTO.SmjerDTOInsertUpdate.Cijena')
  - [IzvodiSeOd](#P-EdunovaAPP-Models-DTO-SmjerDTOInsertUpdate-IzvodiSeOd 'EdunovaAPP.Models.DTO.SmjerDTOInsertUpdate.IzvodiSeOd')
  - [Naziv](#P-EdunovaAPP-Models-DTO-SmjerDTOInsertUpdate-Naziv 'EdunovaAPP.Models.DTO.SmjerDTOInsertUpdate.Naziv')
  - [Vaucer](#P-EdunovaAPP-Models-DTO-SmjerDTOInsertUpdate-Vaucer 'EdunovaAPP.Models.DTO.SmjerDTOInsertUpdate.Vaucer')
- [SmjerDTORead](#T-EdunovaAPP-Models-DTO-SmjerDTORead 'EdunovaAPP.Models.DTO.SmjerDTORead')
  - [#ctor(Sifra,Naziv,Cijena,IzvodiSeOd,Vaucer)](#M-EdunovaAPP-Models-DTO-SmjerDTORead-#ctor-System-Int32,System-String,System-Nullable{System-Decimal},System-Nullable{System-DateTime},System-Nullable{System-Boolean}- 'EdunovaAPP.Models.DTO.SmjerDTORead.#ctor(System.Int32,System.String,System.Nullable{System.Decimal},System.Nullable{System.DateTime},System.Nullable{System.Boolean})')
  - [Cijena](#P-EdunovaAPP-Models-DTO-SmjerDTORead-Cijena 'EdunovaAPP.Models.DTO.SmjerDTORead.Cijena')
  - [IzvodiSeOd](#P-EdunovaAPP-Models-DTO-SmjerDTORead-IzvodiSeOd 'EdunovaAPP.Models.DTO.SmjerDTORead.IzvodiSeOd')
  - [Naziv](#P-EdunovaAPP-Models-DTO-SmjerDTORead-Naziv 'EdunovaAPP.Models.DTO.SmjerDTORead.Naziv')
  - [Sifra](#P-EdunovaAPP-Models-DTO-SmjerDTORead-Sifra 'EdunovaAPP.Models.DTO.SmjerDTORead.Sifra')
  - [Vaucer](#P-EdunovaAPP-Models-DTO-SmjerDTORead-Vaucer 'EdunovaAPP.Models.DTO.SmjerDTORead.Vaucer')

<a name='T-EdunovaAPP-Controllers-AutorizacijaController'></a>
## AutorizacijaController `type`

##### Namespace

EdunovaAPP.Controllers

##### Summary

Kontroler za autorizaciju korisnika.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [T:EdunovaAPP.Controllers.AutorizacijaController](#T-T-EdunovaAPP-Controllers-AutorizacijaController 'T:EdunovaAPP.Controllers.AutorizacijaController') | Kontekst baze podataka. |

##### Remarks

Inicijalizira novu instancu klase [AutorizacijaController](#T-EdunovaAPP-Controllers-AutorizacijaController 'EdunovaAPP.Controllers.AutorizacijaController').

<a name='M-EdunovaAPP-Controllers-AutorizacijaController-#ctor-EdunovaAPP-Data-EdunovaContext-'></a>
### #ctor(context) `constructor`

##### Summary

Kontroler za autorizaciju korisnika.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [EdunovaAPP.Data.EdunovaContext](#T-EdunovaAPP-Data-EdunovaContext 'EdunovaAPP.Data.EdunovaContext') | Kontekst baze podataka. |

##### Remarks

Inicijalizira novu instancu klase [AutorizacijaController](#T-EdunovaAPP-Controllers-AutorizacijaController 'EdunovaAPP.Controllers.AutorizacijaController').

<a name='F-EdunovaAPP-Controllers-AutorizacijaController-_context'></a>
### _context `constants`

##### Summary

Kontekst baze podataka

<a name='M-EdunovaAPP-Controllers-AutorizacijaController-GenerirajToken-EdunovaAPP-Models-DTO-OperaterDTO-'></a>
### GenerirajToken(operater) `method`

##### Summary

Generira token za autorizaciju.

##### Returns

JWT token ako je autorizacija uspješna, inače vraća status 403.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| operater | [EdunovaAPP.Models.DTO.OperaterDTO](#T-EdunovaAPP-Models-DTO-OperaterDTO 'EdunovaAPP.Models.DTO.OperaterDTO') | DTO objekt koji sadrži email i lozinku operatera. |

##### Remarks

Primjer zahtjeva:

```json
{
  "email": "edunova@edunova.hr",
  "password": "edunova"
}
```

<a name='T-EdunovaAPP-Tests-Controllers-AutorizacijaControllerTests'></a>
## AutorizacijaControllerTests `type`

##### Namespace

EdunovaAPP.Tests.Controllers

##### Summary

Testovi za AutorizacijaController.
Ova klasa sadrži testove koji provjeravaju ispravnost generiranja JWT tokena za autorizaciju.

<a name='M-EdunovaAPP-Tests-Controllers-AutorizacijaControllerTests-#ctor'></a>
### #ctor() `constructor`

##### Summary

Inicijalizira novu instancu klase AutorizacijaControllerTests.
Konfigurira kontekst baze vrsta podataka i inicijalizira kontroler.

##### Parameters

This constructor has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-AutorizacijaControllerTests-GenerirajToken_InvalidEmail_ReturnsForbidden'></a>
### GenerirajToken_InvalidEmail_ReturnsForbidden() `method`

##### Summary

Testira slučaj kada uneseni email nije pronađen u bazi.
Očekuje se povrat ObjectResult sa statusom Forbidden i odgovarajućom porukom.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-AutorizacijaControllerTests-GenerirajToken_InvalidModel_ReturnsBadRequest'></a>
### GenerirajToken_InvalidModel_ReturnsBadRequest() `method`

##### Summary

Testira slučaj kada je model operatera neispravan (npr. nedostaje email).
Očekuje se povrat BadRequestObjectResult.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-AutorizacijaControllerTests-GenerirajToken_InvalidPassword_ReturnsForbidden'></a>
### GenerirajToken_InvalidPassword_ReturnsForbidden() `method`

##### Summary

Testira slučaj kada unesena lozinka ne odgovara pohranjenoj u bazi.
Očekuje se povrat ObjectResult sa statusom Forbidden i odgovarajućom porukom.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-AutorizacijaControllerTests-GenerirajToken_ValidCredentials_ReturnsOkWithToken'></a>
### GenerirajToken_ValidCredentials_ReturnsOkWithToken() `method`

##### Summary

Testira generiranje tokena za valjane vjerodajnice.
Očekuje se povrat OkObjectResult s ne-praznim tokenom.

##### Parameters

This method has no parameters.

<a name='T-EdunovaAPP-Data-EdunovaContext'></a>
## EdunovaContext `type`

##### Namespace

EdunovaAPP.Data

##### Summary

Kontekst baze podataka za aplikaciju Edunova.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| opcije | [T:EdunovaAPP.Data.EdunovaContext](#T-T-EdunovaAPP-Data-EdunovaContext 'T:EdunovaAPP.Data.EdunovaContext') | Opcije za konfiguraciju konteksta. |

##### Remarks

Konstruktor koji prima opcije za konfiguraciju konteksta.

<a name='M-EdunovaAPP-Data-EdunovaContext-#ctor-Microsoft-EntityFrameworkCore-DbContextOptions{EdunovaAPP-Data-EdunovaContext}-'></a>
### #ctor(opcije) `constructor`

##### Summary

Kontekst baze podataka za aplikaciju Edunova.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| opcije | [Microsoft.EntityFrameworkCore.DbContextOptions{EdunovaAPP.Data.EdunovaContext}](#T-Microsoft-EntityFrameworkCore-DbContextOptions{EdunovaAPP-Data-EdunovaContext} 'Microsoft.EntityFrameworkCore.DbContextOptions{EdunovaAPP.Data.EdunovaContext}') | Opcije za konfiguraciju konteksta. |

##### Remarks

Konstruktor koji prima opcije za konfiguraciju konteksta.

<a name='P-EdunovaAPP-Data-EdunovaContext-Grupe'></a>
### Grupe `property`

##### Summary

Skup podataka za entitet Grupa.

<a name='P-EdunovaAPP-Data-EdunovaContext-Operateri'></a>
### Operateri `property`

##### Summary

Skup podataka za entitet Operater.

<a name='P-EdunovaAPP-Data-EdunovaContext-Polaznici'></a>
### Polaznici `property`

##### Summary

Skup podataka za entitet Polaznik.

<a name='P-EdunovaAPP-Data-EdunovaContext-Smjerovi'></a>
### Smjerovi `property`

##### Summary

Skup podataka za entitet Smjer.

<a name='M-EdunovaAPP-Data-EdunovaContext-OnModelCreating-Microsoft-EntityFrameworkCore-ModelBuilder-'></a>
### OnModelCreating(modelBuilder) `method`

##### Summary

Konfiguracija modela prilikom kreiranja baze podataka.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| modelBuilder | [Microsoft.EntityFrameworkCore.ModelBuilder](#T-Microsoft-EntityFrameworkCore-ModelBuilder 'Microsoft.EntityFrameworkCore.ModelBuilder') | Graditelj modela. |

<a name='T-EdunovaAPP-Controllers-EdunovaController'></a>
## EdunovaController `type`

##### Namespace

EdunovaAPP.Controllers

##### Summary

Apstraktna klasa EdunovaController koja služi kao osnovna klasa za sve kontrolere u aplikaciji.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [T:EdunovaAPP.Controllers.EdunovaController](#T-T-EdunovaAPP-Controllers-EdunovaController 'T:EdunovaAPP.Controllers.EdunovaController') | Instanca EdunovaContext klase koja se koristi za pristup bazi podataka. |

<a name='M-EdunovaAPP-Controllers-EdunovaController-#ctor-EdunovaAPP-Data-EdunovaContext,AutoMapper-IMapper-'></a>
### #ctor(context,mapper) `constructor`

##### Summary

Apstraktna klasa EdunovaController koja služi kao osnovna klasa za sve kontrolere u aplikaciji.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [EdunovaAPP.Data.EdunovaContext](#T-EdunovaAPP-Data-EdunovaContext 'EdunovaAPP.Data.EdunovaContext') | Instanca EdunovaContext klase koja se koristi za pristup bazi podataka. |
| mapper | [AutoMapper.IMapper](#T-AutoMapper-IMapper 'AutoMapper.IMapper') | Instanca IMapper sučelja koja se koristi za mapiranje objekata. |

<a name='F-EdunovaAPP-Controllers-EdunovaController-_context'></a>
### _context `constants`

##### Summary

Kontekst baze podataka.

<a name='F-EdunovaAPP-Controllers-EdunovaController-_mapper'></a>
### _mapper `constants`

##### Summary

Mapper za mapiranje objekata.

<a name='T-EdunovaAPP-Extensions-EdunovaExtensions'></a>
## EdunovaExtensions `type`

##### Namespace

EdunovaAPP.Extensions

##### Summary

Klasa koja sadrži proširenja za Edunova aplikaciju.

<a name='M-EdunovaAPP-Extensions-EdunovaExtensions-AddEdunovaCORS-Microsoft-Extensions-DependencyInjection-IServiceCollection-'></a>
### AddEdunovaCORS(Services) `method`

##### Summary

Dodaje konfiguraciju za CORS.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Services | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | Instanca IServiceCollection. |

<a name='M-EdunovaAPP-Extensions-EdunovaExtensions-AddEdunovaSecurity-Microsoft-Extensions-DependencyInjection-IServiceCollection-'></a>
### AddEdunovaSecurity(Services) `method`

##### Summary

Dodaje konfiguraciju za sigurnost.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Services | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | Instanca IServiceCollection. |

<a name='M-EdunovaAPP-Extensions-EdunovaExtensions-AddEdunovaSwaggerGen-Microsoft-Extensions-DependencyInjection-IServiceCollection-'></a>
### AddEdunovaSwaggerGen(Services) `method`

##### Summary

Dodaje konfiguraciju za Swagger dokumentaciju.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Services | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | Instanca IServiceCollection. |

<a name='T-EdunovaAPP-Mapping-EdunovaMappingProfile'></a>
## EdunovaMappingProfile `type`

##### Namespace

EdunovaAPP.Mapping

##### Summary

Klasa za definiranje mapiranja između modela i DTO objekata.

<a name='M-EdunovaAPP-Mapping-EdunovaMappingProfile-#ctor'></a>
### #ctor() `constructor`

##### Summary

Konstruktor u kojem se definiraju mapiranja.

##### Parameters

This constructor has no parameters.

<a name='M-EdunovaAPP-Mapping-EdunovaMappingProfile-PutanjaDatoteke-EdunovaAPP-Models-Polaznik-'></a>
### PutanjaDatoteke(e) `method`

##### Summary

Metoda za dobivanje putanje do slike polaznika.

##### Returns

Putanja do slike ili null ako slika ne postoji.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [EdunovaAPP.Models.Polaznik](#T-EdunovaAPP-Models-Polaznik 'EdunovaAPP.Models.Polaznik') | Objekt polaznika. |

<a name='T-EdunovaAPP-Models-Entitet'></a>
## Entitet `type`

##### Namespace

EdunovaAPP.Models

##### Summary

Apstraktna klasa koja predstavlja entitet s jedinstvenim identifikatorom.

<a name='P-EdunovaAPP-Models-Entitet-Sifra'></a>
### Sifra `property`

##### Summary

Jedinstveni identifikator entiteta.

<a name='T-EdunovaAPP-Models-DTO-GrafGrupaDTO'></a>
## GrafGrupaDTO `type`

##### Namespace

EdunovaAPP.Models.DTO

##### Summary

DTO klasa koja predstavlja graf grupe.

<a name='M-EdunovaAPP-Models-DTO-GrafGrupaDTO-#ctor-System-String,System-Int32-'></a>
### #ctor() `constructor`

##### Summary

DTO klasa koja predstavlja graf grupe.

##### Parameters

This constructor has no parameters.

<a name='T-EdunovaAPP-Models-Grupa'></a>
## Grupa `type`

##### Namespace

EdunovaAPP.Models

##### Summary

Klasa koja predstavlja grupu.

<a name='P-EdunovaAPP-Models-Grupa-MaksimalnoPolaznika'></a>
### MaksimalnoPolaznika `property`

##### Summary

Maksimalan broj polaznika u grupi.

<a name='P-EdunovaAPP-Models-Grupa-Naziv'></a>
### Naziv `property`

##### Summary

Naziv grupe.

<a name='P-EdunovaAPP-Models-Grupa-Polaznici'></a>
### Polaznici `property`

##### Summary

Polaznici koji su upisani u grupu.

<a name='P-EdunovaAPP-Models-Grupa-Predavac'></a>
### Predavac `property`

##### Summary

Predavač grupe.

<a name='P-EdunovaAPP-Models-Grupa-Smjer'></a>
### Smjer `property`

##### Summary

Smjer kojem grupa pripada.

<a name='T-EdunovaAPP-Controllers-GrupaController'></a>
## GrupaController `type`

##### Namespace

EdunovaAPP.Controllers

##### Summary

Kontroler za upravljanje grupama u aplikaciji.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [T:EdunovaAPP.Controllers.GrupaController](#T-T-EdunovaAPP-Controllers-GrupaController 'T:EdunovaAPP.Controllers.GrupaController') | Instanca EdunovaContext klase koja se koristi za pristup bazi podataka. |

<a name='M-EdunovaAPP-Controllers-GrupaController-#ctor-EdunovaAPP-Data-EdunovaContext,AutoMapper-IMapper-'></a>
### #ctor(context,mapper) `constructor`

##### Summary

Kontroler za upravljanje grupama u aplikaciji.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [EdunovaAPP.Data.EdunovaContext](#T-EdunovaAPP-Data-EdunovaContext 'EdunovaAPP.Data.EdunovaContext') | Instanca EdunovaContext klase koja se koristi za pristup bazi podataka. |
| mapper | [AutoMapper.IMapper](#T-AutoMapper-IMapper 'AutoMapper.IMapper') | Instanca IMapper sučelja koja se koristi za mapiranje objekata. |

<a name='M-EdunovaAPP-Controllers-GrupaController-Delete-System-Int32-'></a>
### Delete(sifra) `method`

##### Summary

Briše grupu prema šifri.

##### Returns

Status brisanja.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra grupe. |

<a name='M-EdunovaAPP-Controllers-GrupaController-DodajPolaznika-System-Int32,System-Int32-'></a>
### DodajPolaznika(sifra,polaznikSifra) `method`

##### Summary

Dodaje polaznika u grupu.

##### Returns

Status dodavanja.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra grupe. |
| polaznikSifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra polaznika. |

<a name='M-EdunovaAPP-Controllers-GrupaController-Get'></a>
### Get() `method`

##### Summary

Dohvaća sve grupe.

##### Returns

Lista grupa.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Controllers-GrupaController-GetBySifra-System-Int32-'></a>
### GetBySifra(sifra) `method`

##### Summary

Dohvaća grupu prema šifri.

##### Returns

Grupa sa zadanom šifrom.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra grupe. |

<a name='M-EdunovaAPP-Controllers-GrupaController-GetPolaznici-System-Int32-'></a>
### GetPolaznici(sifraGrupe) `method`

##### Summary

Dohvaća polaznike grupe prema šifri grupe.

##### Returns

Lista polaznika grupe.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sifraGrupe | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra grupe. |

<a name='M-EdunovaAPP-Controllers-GrupaController-GrafGrupe'></a>
### GrafGrupe() `method`

##### Summary

Dohvaća graf grupe.

##### Returns

Lista grafova grupa.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Controllers-GrupaController-ObrisiPolaznika-System-Int32,System-Int32-'></a>
### ObrisiPolaznika(sifra,polaznikSifra) `method`

##### Summary

Briše polaznika iz grupe.

##### Returns

Status brisanja.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra grupe. |
| polaznikSifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra polaznika. |

<a name='M-EdunovaAPP-Controllers-GrupaController-Post-EdunovaAPP-Models-DTO-GrupaDTOInsertUpdate-'></a>
### Post(dto) `method`

##### Summary

Dodaje novu grupu.

##### Returns

Status kreiranja.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dto | [EdunovaAPP.Models.DTO.GrupaDTOInsertUpdate](#T-EdunovaAPP-Models-DTO-GrupaDTOInsertUpdate 'EdunovaAPP.Models.DTO.GrupaDTOInsertUpdate') | Podaci o grupi. |

<a name='M-EdunovaAPP-Controllers-GrupaController-Put-System-Int32,EdunovaAPP-Models-DTO-GrupaDTOInsertUpdate-'></a>
### Put(sifra,dto) `method`

##### Summary

Ažurira postojeću grupu.

##### Returns

Status ažuriranja.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra grupe. |
| dto | [EdunovaAPP.Models.DTO.GrupaDTOInsertUpdate](#T-EdunovaAPP-Models-DTO-GrupaDTOInsertUpdate 'EdunovaAPP.Models.DTO.GrupaDTOInsertUpdate') | Podaci o grupi. |

<a name='T-EdunovaAPP-Tests-Controllers-GrupaControllerTests'></a>
## GrupaControllerTests `type`

##### Namespace

EdunovaAPP.Tests.Controllers

##### Summary

Test klasa za GrupaController sadrži testove za sve akcije kontrolera.

<a name='M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-#ctor'></a>
### #ctor() `constructor`

##### Summary

Konstruktor koji inicijalizira testni kontekst i zavisnosti.

##### Parameters

This constructor has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-Delete_ExistingGrupa_ReturnsOkWithSuccessMessage'></a>
### Delete_ExistingGrupa_ReturnsOkWithSuccessMessage() `method`

##### Summary

Testira metodu Delete() za postojeću grupu; očekuje OK rezultat s porukom o uspješnom brisanju.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-Delete_NonExistingGrupa_ReturnsNotFound'></a>
### Delete_NonExistingGrupa_ReturnsNotFound() `method`

##### Summary

Testira metodu Delete() za nepostojeću grupu; očekuje NotFound rezultat.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-DodajPolaznika_NonExistingGrupa_ReturnsBadRequest'></a>
### DodajPolaznika_NonExistingGrupa_ReturnsBadRequest() `method`

##### Summary

Testira metodu DodajPolaznika() za nepostojeću grupu; očekuje BadRequest rezultat.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-DodajPolaznika_NonExistingPolaznik_ReturnsBadRequest'></a>
### DodajPolaznika_NonExistingPolaznik_ReturnsBadRequest() `method`

##### Summary

Testira metodu DodajPolaznika() za nepostojećeg polaznika; očekuje BadRequest rezultat.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-DodajPolaznika_ValidParameters_ReturnsOkWithSuccessMessage'></a>
### DodajPolaznika_ValidParameters_ReturnsOkWithSuccessMessage() `method`

##### Summary

Testira metodu DodajPolaznika() s važećim parametrima; očekuje OK rezultat s porukom o uspješnom dodavanju polaznika.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-GetBySifra_ExistingGrupa_ReturnsOkWithGrupa'></a>
### GetBySifra_ExistingGrupa_ReturnsOkWithGrupa() `method`

##### Summary

Testira metodu GetBySifra() kod postojeće grupe; očekuje OK rezultat s grupom.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-GetBySifra_NonExistingGrupa_ReturnsNotFound'></a>
### GetBySifra_NonExistingGrupa_ReturnsNotFound() `method`

##### Summary

Testira metodu GetBySifra() za nepostojeću grupu; očekuje NotFound rezultat.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-GetPolaznici_ExistingGrupa_ReturnsOkWithPolaznici'></a>
### GetPolaznici_ExistingGrupa_ReturnsOkWithPolaznici() `method`

##### Summary

Testira metodu GetPolaznici() za postojeću grupu; očekuje OK rezultat s listom polaznika.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-GetPolaznici_NonExistingGrupa_ReturnsBadRequest'></a>
### GetPolaznici_NonExistingGrupa_ReturnsBadRequest() `method`

##### Summary

Testira metodu GetPolaznici() za nepostojeću grupu; očekuje BadRequest rezultat.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-Get_ReturnsOkWithGrupaList'></a>
### Get_ReturnsOkWithGrupaList() `method`

##### Summary

Testira metodu Get() koja vraća OK rezultat s listom grupa.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-GrafGrupe_ReturnsOkWithGrafGrupaList'></a>
### GrafGrupe_ReturnsOkWithGrafGrupaList() `method`

##### Summary

Testira metodu GrafGrupe() koja dohvaća podatke za graf grupa; očekuje OK rezultat s grafom grupa.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-ObrisiPolaznika_ValidParameters_ReturnsOkWithSuccessMessage'></a>
### ObrisiPolaznika_ValidParameters_ReturnsOkWithSuccessMessage() `method`

##### Summary

Testira metodu ObrisiPolaznika() s važećim parametrima; očekuje OK rezultat s porukom o uspješnom brisanju polaznika iz grupe.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-Post_NonExistingSmjer_ReturnsNotFound'></a>
### Post_NonExistingSmjer_ReturnsNotFound() `method`

##### Summary

Testira metodu Post() za slučaj kada ne postoji Smjer; očekuje NotFound rezultat.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-Post_ValidGrupa_ReturnsCreatedWithGrupa'></a>
### Post_ValidGrupa_ReturnsCreatedWithGrupa() `method`

##### Summary

Testira metodu Post() za validnu grupu; očekuje Created rezultat s novokreiranom grupom.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-Put_ExistingGrupa_ReturnsOkWithSuccessMessage'></a>
### Put_ExistingGrupa_ReturnsOkWithSuccessMessage() `method`

##### Summary

Testira metodu Put() za postojeću grupu; očekuje OK rezultat s porukom o uspješnoj promjeni.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-GrupaControllerTests-Put_NonExistingGrupa_ReturnsNotFound'></a>
### Put_NonExistingGrupa_ReturnsNotFound() `method`

##### Summary

Testira metodu Put() za nepostojeću grupu; očekuje NotFound rezultat.

##### Parameters

This method has no parameters.

<a name='T-EdunovaAPP-Models-DTO-GrupaDTOInsertUpdate'></a>
## GrupaDTOInsertUpdate `type`

##### Namespace

EdunovaAPP.Models.DTO

##### Summary

DTO za unos i ažuriranje grupe.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Naziv | [T:EdunovaAPP.Models.DTO.GrupaDTOInsertUpdate](#T-T-EdunovaAPP-Models-DTO-GrupaDTOInsertUpdate 'T:EdunovaAPP.Models.DTO.GrupaDTOInsertUpdate') | Naziv grupe (obavezno). |

<a name='M-EdunovaAPP-Models-DTO-GrupaDTOInsertUpdate-#ctor-System-String,System-Nullable{System-Int32},System-String,System-Int32-'></a>
### #ctor(Naziv,SmjerSifra,Predavac,MaksimalnoPolaznika) `constructor`

##### Summary

DTO za unos i ažuriranje grupe.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Naziv | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Naziv grupe (obavezno). |
| SmjerSifra | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | Šifra smjera (obavezno, mora biti između 1 i int.MaxValue). |
| Predavac | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Ime predavača. |
| MaksimalnoPolaznika | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Maksimalan broj polaznika (obavezno, mora biti između 5 i 30). |

<a name='P-EdunovaAPP-Models-DTO-GrupaDTOInsertUpdate-MaksimalnoPolaznika'></a>
### MaksimalnoPolaznika `property`

##### Summary

Maksimalan broj polaznika (obavezno, mora biti između 5 i 30).

<a name='P-EdunovaAPP-Models-DTO-GrupaDTOInsertUpdate-Naziv'></a>
### Naziv `property`

##### Summary

Naziv grupe (obavezno).

<a name='P-EdunovaAPP-Models-DTO-GrupaDTOInsertUpdate-Predavac'></a>
### Predavac `property`

##### Summary

Ime predavača.

<a name='P-EdunovaAPP-Models-DTO-GrupaDTOInsertUpdate-SmjerSifra'></a>
### SmjerSifra `property`

##### Summary

Šifra smjera (obavezno, mora biti između 1 i int.MaxValue).

<a name='T-EdunovaAPP-Models-DTO-GrupaDTORead'></a>
## GrupaDTORead `type`

##### Namespace

EdunovaAPP.Models.DTO

##### Summary

DTO za čitanje podataka o grupi.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Sifra | [T:EdunovaAPP.Models.DTO.GrupaDTORead](#T-T-EdunovaAPP-Models-DTO-GrupaDTORead 'T:EdunovaAPP.Models.DTO.GrupaDTORead') | Jedinstveni identifikator grupe. |

<a name='M-EdunovaAPP-Models-DTO-GrupaDTORead-#ctor-System-Int32,System-String,System-String,System-String,System-Nullable{System-Int32}-'></a>
### #ctor(Sifra,Naziv,SmjerNaziv,Predavac,MaksimalnoPolaznika) `constructor`

##### Summary

DTO za čitanje podataka o grupi.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Jedinstveni identifikator grupe. |
| Naziv | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Naziv grupe. |
| SmjerNaziv | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Naziv smjera kojem grupa pripada. |
| Predavac | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Ime predavača grupe. |
| MaksimalnoPolaznika | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | Maksimalan broj polaznika u grupi. |

<a name='P-EdunovaAPP-Models-DTO-GrupaDTORead-MaksimalnoPolaznika'></a>
### MaksimalnoPolaznika `property`

##### Summary

Maksimalan broj polaznika u grupi.

<a name='P-EdunovaAPP-Models-DTO-GrupaDTORead-Naziv'></a>
### Naziv `property`

##### Summary

Naziv grupe.

<a name='P-EdunovaAPP-Models-DTO-GrupaDTORead-Predavac'></a>
### Predavac `property`

##### Summary

Ime predavača grupe.

<a name='P-EdunovaAPP-Models-DTO-GrupaDTORead-Sifra'></a>
### Sifra `property`

##### Summary

Jedinstveni identifikator grupe.

<a name='P-EdunovaAPP-Models-DTO-GrupaDTORead-SmjerNaziv'></a>
### SmjerNaziv `property`

##### Summary

Naziv smjera kojem grupa pripada.

<a name='T-EdunovaAPP-Models-Operater'></a>
## Operater `type`

##### Namespace

EdunovaAPP.Models

##### Summary

Operater koji se koristi za prijavu u sustav.

<a name='P-EdunovaAPP-Models-Operater-Email'></a>
### Email `property`

##### Summary

Email operatera.

<a name='P-EdunovaAPP-Models-Operater-Lozinka'></a>
### Lozinka `property`

##### Summary

Lozinka operatera.

<a name='T-EdunovaAPP-Models-DTO-OperaterDTO'></a>
## OperaterDTO `type`

##### Namespace

EdunovaAPP.Models.DTO

##### Summary

DTO (Data Transfer Object) za operatera.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Email | [T:EdunovaAPP.Models.DTO.OperaterDTO](#T-T-EdunovaAPP-Models-DTO-OperaterDTO 'T:EdunovaAPP.Models.DTO.OperaterDTO') |  |

<a name='M-EdunovaAPP-Models-DTO-OperaterDTO-#ctor-System-String,System-String-'></a>
### #ctor(Email,Password) `constructor`

##### Summary

DTO (Data Transfer Object) za operatera.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Email | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| Password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='P-EdunovaAPP-Models-DTO-OperaterDTO-Email'></a>
### Email `property`

##### Summary



<a name='P-EdunovaAPP-Models-DTO-OperaterDTO-Password'></a>
### Password `property`

##### Summary



<a name='T-EdunovaAPP-Controllers-PocetnaController'></a>
## PocetnaController `type`

##### Namespace

EdunovaAPP.Controllers

##### Summary

Kontroler za početne operacije.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| _context | [T:EdunovaAPP.Controllers.PocetnaController](#T-T-EdunovaAPP-Controllers-PocetnaController 'T:EdunovaAPP.Controllers.PocetnaController') | Kontekst baze podataka. |

<a name='M-EdunovaAPP-Controllers-PocetnaController-#ctor-EdunovaAPP-Data-EdunovaContext-'></a>
### #ctor(_context) `constructor`

##### Summary

Kontroler za početne operacije.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| _context | [EdunovaAPP.Data.EdunovaContext](#T-EdunovaAPP-Data-EdunovaContext 'EdunovaAPP.Data.EdunovaContext') | Kontekst baze podataka. |

<a name='M-EdunovaAPP-Controllers-PocetnaController-DostupniSmjerovi'></a>
### DostupniSmjerovi() `method`

##### Summary

Dohvaća dostupne smjerove.

##### Returns

Lista dostupnih smjerova.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Controllers-PocetnaController-UkupnoPolaznika'></a>
### UkupnoPolaznika() `method`

##### Summary

Dohvaća ukupan broj polaznika.

##### Returns

Ukupan broj polaznika.

##### Parameters

This method has no parameters.

<a name='T-EdunovaAPP-Tests-Controllers-PocetnaControllerTests'></a>
## PocetnaControllerTests `type`

##### Namespace

EdunovaAPP.Tests.Controllers

##### Summary

Test klasa za testiranje metode unutar PocetnaController.

<a name='M-EdunovaAPP-Tests-Controllers-PocetnaControllerTests-#ctor'></a>
### #ctor() `constructor`

##### Summary

Konstruktor koji inicijalizira test kontekst i kontroler.

##### Parameters

This constructor has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-PocetnaControllerTests-DostupniSmjerovi_DatabaseError_ReturnsBadRequest'></a>
### DostupniSmjerovi_DatabaseError_ReturnsBadRequest() `method`

##### Summary

Testira metodu DostupniSmjerovi u slučaju greške u bazi podataka, te očekuje BadRequest rezultat.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-PocetnaControllerTests-DostupniSmjerovi_EmptyDatabase_ReturnsEmptyList'></a>
### DostupniSmjerovi_EmptyDatabase_ReturnsEmptyList() `method`

##### Summary

Testira metodu DostupniSmjerovi kada baza ne sadrži podatke, te očekuje praznu listu.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-PocetnaControllerTests-DostupniSmjerovi_ReturnsOkWithSmjerList'></a>
### DostupniSmjerovi_ReturnsOkWithSmjerList() `method`

##### Summary

Testira metodu DostupniSmjerovi da vraća Ok rezultat sa listom smjerova.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-PocetnaControllerTests-UkupnoPolaznika_DatabaseError_ReturnsBadRequest'></a>
### UkupnoPolaznika_DatabaseError_ReturnsBadRequest() `method`

##### Summary

Testira metodu UkupnoPolaznika u slučaju greške u bazi podataka, te očekuje BadRequest rezultat.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-PocetnaControllerTests-UkupnoPolaznika_EmptyDatabase_ReturnsZero'></a>
### UkupnoPolaznika_EmptyDatabase_ReturnsZero() `method`

##### Summary

Testira metodu UkupnoPolaznika kada baza ne sadrži podatke, te očekuje da se vrati broj nula.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-PocetnaControllerTests-UkupnoPolaznika_ReturnsOkWithCount'></a>
### UkupnoPolaznika_ReturnsOkWithCount() `method`

##### Summary

Testira metodu UkupnoPolaznika da vraća Ok rezultat sa ispravnim brojem polaznika.

##### Parameters

This method has no parameters.

<a name='T-EdunovaAPP-Models-Polaznik'></a>
## Polaznik `type`

##### Namespace

EdunovaAPP.Models

##### Summary

Klasa koja predstavlja polaznika.

<a name='P-EdunovaAPP-Models-Polaznik-Email'></a>
### Email `property`

##### Summary

Email polaznika.

<a name='P-EdunovaAPP-Models-Polaznik-Grupe'></a>
### Grupe `property`

##### Summary

Grupe u koje je polaznik upisan.

<a name='P-EdunovaAPP-Models-Polaznik-Ime'></a>
### Ime `property`

##### Summary

Ime polaznika.

<a name='P-EdunovaAPP-Models-Polaznik-Oib'></a>
### Oib `property`

##### Summary

OIB polaznika.

<a name='P-EdunovaAPP-Models-Polaznik-Prezime'></a>
### Prezime `property`

##### Summary

Prezime polaznika.

<a name='T-EdunovaAPP-Controllers-PolaznikController'></a>
## PolaznikController `type`

##### Namespace

EdunovaAPP.Controllers

##### Summary

Kontroler za upravljanje polaznicima.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [T:EdunovaAPP.Controllers.PolaznikController](#T-T-EdunovaAPP-Controllers-PolaznikController 'T:EdunovaAPP.Controllers.PolaznikController') | Kontekst baze podataka. |

<a name='M-EdunovaAPP-Controllers-PolaznikController-#ctor-EdunovaAPP-Data-EdunovaContext,AutoMapper-IMapper-'></a>
### #ctor(context,mapper) `constructor`

##### Summary

Kontroler za upravljanje polaznicima.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [EdunovaAPP.Data.EdunovaContext](#T-EdunovaAPP-Data-EdunovaContext 'EdunovaAPP.Data.EdunovaContext') | Kontekst baze podataka. |
| mapper | [AutoMapper.IMapper](#T-AutoMapper-IMapper 'AutoMapper.IMapper') | Mapper za mapiranje objekata. |

<a name='M-EdunovaAPP-Controllers-PolaznikController-Delete-System-Int32-'></a>
### Delete(sifra) `method`

##### Summary

Briše polaznika prema šifri.

##### Returns

Status brisanja.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra polaznika. |

<a name='M-EdunovaAPP-Controllers-PolaznikController-Generiraj-System-Int32-'></a>
### Generiraj(broj) `method`

##### Summary

Generira polaznike.

##### Returns

Status generiranja.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| broj | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Broj polaznika za generiranje. |

<a name='M-EdunovaAPP-Controllers-PolaznikController-Get'></a>
### Get() `method`

##### Summary

Dohvaća sve polaznike.

##### Returns

Lista polaznika.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Controllers-PolaznikController-GetBySifra-System-Int32-'></a>
### GetBySifra(sifra) `method`

##### Summary

Dohvaća polaznika prema šifri.

##### Returns

Polaznik.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra polaznika. |

<a name='M-EdunovaAPP-Controllers-PolaznikController-Post-EdunovaAPP-Models-DTO-PolaznikDTOInsertUpdate-'></a>
### Post(dto) `method`

##### Summary

Dodaje novog polaznika.

##### Returns

Status kreiranja.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dto | [EdunovaAPP.Models.DTO.PolaznikDTOInsertUpdate](#T-EdunovaAPP-Models-DTO-PolaznikDTOInsertUpdate 'EdunovaAPP.Models.DTO.PolaznikDTOInsertUpdate') | Podaci o polazniku. |

<a name='M-EdunovaAPP-Controllers-PolaznikController-PostaviSliku-System-Int32,EdunovaAPP-Models-DTO-SlikaDTO-'></a>
### PostaviSliku(sifra,slika) `method`

##### Summary

Postavlja sliku za polaznika.

##### Returns

Status postavljanja slike.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra polaznika. |
| slika | [EdunovaAPP.Models.DTO.SlikaDTO](#T-EdunovaAPP-Models-DTO-SlikaDTO 'EdunovaAPP.Models.DTO.SlikaDTO') | Podaci o slici. |

<a name='M-EdunovaAPP-Controllers-PolaznikController-Put-System-Int32,EdunovaAPP-Models-DTO-PolaznikDTOInsertUpdate-'></a>
### Put(sifra,dto) `method`

##### Summary

Ažurira polaznika prema šifri.

##### Returns

Status ažuriranja.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra polaznika. |
| dto | [EdunovaAPP.Models.DTO.PolaznikDTOInsertUpdate](#T-EdunovaAPP-Models-DTO-PolaznikDTOInsertUpdate 'EdunovaAPP.Models.DTO.PolaznikDTOInsertUpdate') | Podaci o polazniku. |

<a name='M-EdunovaAPP-Controllers-PolaznikController-TraziPolaznik-System-String-'></a>
### TraziPolaznik(uvjet) `method`

##### Summary

Traži polaznike prema uvjetu.

##### Returns

Lista polaznika.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| uvjet | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Uvjet pretrage. |

<a name='M-EdunovaAPP-Controllers-PolaznikController-TraziPolaznikStranicenje-System-Int32,System-String-'></a>
### TraziPolaznikStranicenje(stranica,uvjet) `method`

##### Summary

Traži polaznike s paginacijom.

##### Returns

Lista polaznika.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| stranica | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Broj stranice. |
| uvjet | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Uvjet pretrage. |

<a name='T-EdunovaAPP-Tests-Controllers-PolaznikControllerTests'></a>
## PolaznikControllerTests `type`

##### Namespace

EdunovaAPP.Tests.Controllers

##### Summary

Test klasa za PolaznikController.
Sadrži testove za sve REST API metode unutar kontrolera.

<a name='M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-#ctor'></a>
### #ctor() `constructor`

##### Summary

Konstruktor klase, postavlja in-memory bazu podataka, mapper te instancu kontrolera.

##### Parameters

This constructor has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-Delete_ExistingPolaznik_ReturnsOkWithSuccessMessage'></a>
### Delete_ExistingPolaznik_ReturnsOkWithSuccessMessage() `method`

##### Summary

Testira DELETE metodu za brisanje postojećeg polaznika.
Provjerava se uspješno brisanje i odgovarajuća poruka.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-Delete_NonExistingPolaznik_ReturnsNotFound'></a>
### Delete_NonExistingPolaznik_ReturnsNotFound() `method`

##### Summary

Testira DELETE metodu kada polaznik ne postoji.
Očekuje NotFound rezultat.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-GetBySifra_ExistingPolaznik_ReturnsOkWithPolaznik'></a>
### GetBySifra_ExistingPolaznik_ReturnsOkWithPolaznik() `method`

##### Summary

Testira GET metodu koja dohvaća polaznika prema šifri kada polaznik postoji.
Provjerava jesu li vraćeni podaci ispravni.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-GetBySifra_NonExistingPolaznik_ReturnsNotFound'></a>
### GetBySifra_NonExistingPolaznik_ReturnsNotFound() `method`

##### Summary

Testira GET metodu kada polaznik s danom šifrom ne postoji.
Očekuje NotFound rezultat.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-Get_ReturnsOkWithPolaznikList'></a>
### Get_ReturnsOkWithPolaznikList() `method`

##### Summary

Testira GET metodu koja vraća listu polaznika i osigurava da se vraćeni rezultat ispravno mapira.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-Post_ValidPolaznik_ReturnsCreatedWithPolaznik'></a>
### Post_ValidPolaznik_ReturnsCreatedWithPolaznik() `method`

##### Summary

Testira POST metodu za dodavanje novog polaznika.
Provjerava se kreiranje polaznika i vraćanje ispravnih podataka.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-Put_ExistingPolaznik_ReturnsOkWithSuccessMessage'></a>
### Put_ExistingPolaznik_ReturnsOkWithSuccessMessage() `method`

##### Summary

Testira PUT metodu za ažuriranje postojećeg polaznika.
Provjerava se uspješnost promjene podataka.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-Put_NonExistingPolaznik_ReturnsNotFound'></a>
### Put_NonExistingPolaznik_ReturnsNotFound() `method`

##### Summary

Testira PUT metodu za ažuriranje polaznika koji ne postoji.
Očekuje NotFound rezultat.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-TraziPolaznikStranicenje_ValidParameters_ReturnsPagedResults'></a>
### TraziPolaznikStranicenje_ValidParameters_ReturnsPagedResults() `method`

##### Summary

Testira metodu TraziPolaznikStranicenje koja vraća paginirane rezultate.
Provjerava se ispravnost paginacije.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-TraziPolaznik_ShortSearchTerm_ReturnsBadRequest'></a>
### TraziPolaznik_ShortSearchTerm_ReturnsBadRequest() `method`

##### Summary

Testira metodu TraziPolaznik kada je uvjet pretraživanja prekratak.
Očekuje BadRequest rezultat.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-PolaznikControllerTests-TraziPolaznik_ValidSearchTerm_ReturnsMatchingPolaznici'></a>
### TraziPolaznik_ValidSearchTerm_ReturnsMatchingPolaznici() `method`

##### Summary

Testira metodu TraziPolaznik koja vraća listu polaznika prema zadanom uvjetu pretrage.
Provjerava se ispravnost filtriranja po uvjetu.

##### Parameters

This method has no parameters.

<a name='T-EdunovaAPP-Models-DTO-PolaznikDTOInsertUpdate'></a>
## PolaznikDTOInsertUpdate `type`

##### Namespace

EdunovaAPP.Models.DTO

##### Summary

DTO za unos i ažuriranje polaznika.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Ime | [T:EdunovaAPP.Models.DTO.PolaznikDTOInsertUpdate](#T-T-EdunovaAPP-Models-DTO-PolaznikDTOInsertUpdate 'T:EdunovaAPP.Models.DTO.PolaznikDTOInsertUpdate') | Ime polaznika. Obavezno polje. |

<a name='M-EdunovaAPP-Models-DTO-PolaznikDTOInsertUpdate-#ctor-System-String,System-String,System-String,System-String-'></a>
### #ctor(Ime,Prezime,Email,Oib) `constructor`

##### Summary

DTO za unos i ažuriranje polaznika.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Ime | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Ime polaznika. Obavezno polje. |
| Prezime | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Prezime polaznika. Obavezno polje. |
| Email | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Email polaznika. Obavezno polje. Mora biti u ispravnom formatu. |
| Oib | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | OIB polaznika. |

<a name='P-EdunovaAPP-Models-DTO-PolaznikDTOInsertUpdate-Email'></a>
### Email `property`

##### Summary

Email polaznika. Obavezno polje. Mora biti u ispravnom formatu.

<a name='P-EdunovaAPP-Models-DTO-PolaznikDTOInsertUpdate-Ime'></a>
### Ime `property`

##### Summary

Ime polaznika. Obavezno polje.

<a name='P-EdunovaAPP-Models-DTO-PolaznikDTOInsertUpdate-Oib'></a>
### Oib `property`

##### Summary

OIB polaznika.

<a name='P-EdunovaAPP-Models-DTO-PolaznikDTOInsertUpdate-Prezime'></a>
### Prezime `property`

##### Summary

Prezime polaznika. Obavezno polje.

<a name='T-EdunovaAPP-Models-DTO-PolaznikDTORead'></a>
## PolaznikDTORead `type`

##### Namespace

EdunovaAPP.Models.DTO

##### Summary

DTO za čitanje podataka o polazniku.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Sifra | [T:EdunovaAPP.Models.DTO.PolaznikDTORead](#T-T-EdunovaAPP-Models-DTO-PolaznikDTORead 'T:EdunovaAPP.Models.DTO.PolaznikDTORead') | Jedinstveni identifikator polaznika. |

<a name='M-EdunovaAPP-Models-DTO-PolaznikDTORead-#ctor-System-Nullable{System-Int32},System-String,System-String,System-String,System-String,System-String-'></a>
### #ctor(Sifra,Ime,Prezime,Email,Oib,Slika) `constructor`

##### Summary

DTO za čitanje podataka o polazniku.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Sifra | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | Jedinstveni identifikator polaznika. |
| Ime | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Ime polaznika. |
| Prezime | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Prezime polaznika. |
| Email | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Email adresa polaznika. |
| Oib | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | OIB polaznika (opcionalno). |
| Slika | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | URL slike polaznika (opcionalno). |

<a name='P-EdunovaAPP-Models-DTO-PolaznikDTORead-Email'></a>
### Email `property`

##### Summary

Email adresa polaznika.

<a name='P-EdunovaAPP-Models-DTO-PolaznikDTORead-Ime'></a>
### Ime `property`

##### Summary

Ime polaznika.

<a name='P-EdunovaAPP-Models-DTO-PolaznikDTORead-Oib'></a>
### Oib `property`

##### Summary

OIB polaznika (opcionalno).

<a name='P-EdunovaAPP-Models-DTO-PolaznikDTORead-Prezime'></a>
### Prezime `property`

##### Summary

Prezime polaznika.

<a name='P-EdunovaAPP-Models-DTO-PolaznikDTORead-Sifra'></a>
### Sifra `property`

##### Summary

Jedinstveni identifikator polaznika.

<a name='P-EdunovaAPP-Models-DTO-PolaznikDTORead-Slika'></a>
### Slika `property`

##### Summary

URL slike polaznika (opcionalno).

<a name='T-EdunovaAPP-Models-DTO-SlikaDTO'></a>
## SlikaDTO `type`

##### Namespace

EdunovaAPP.Models.DTO

##### Summary

DTO za unos slike.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Base64 | [T:EdunovaAPP.Models.DTO.SlikaDTO](#T-T-EdunovaAPP-Models-DTO-SlikaDTO 'T:EdunovaAPP.Models.DTO.SlikaDTO') | Slika zapisana u Base64 formatu |

<a name='M-EdunovaAPP-Models-DTO-SlikaDTO-#ctor-System-String-'></a>
### #ctor(Base64) `constructor`

##### Summary

DTO za unos slike.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Base64 | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Slika zapisana u Base64 formatu |

<a name='P-EdunovaAPP-Models-DTO-SlikaDTO-Base64'></a>
### Base64 `property`

##### Summary

Slika zapisana u Base64 formatu

<a name='T-EdunovaAPP-Models-Smjer'></a>
## Smjer `type`

##### Namespace

EdunovaAPP.Models

##### Summary

Predstavlja smjer u sustavu.

<a name='P-EdunovaAPP-Models-Smjer-Cijena'></a>
### Cijena `property`

##### Summary

Cijena smjera.

<a name='P-EdunovaAPP-Models-Smjer-IzvodiSeOd'></a>
### IzvodiSeOd `property`

##### Summary

Datum od kada se smjer izvodi.

<a name='P-EdunovaAPP-Models-Smjer-Naziv'></a>
### Naziv `property`

##### Summary

Naziv smjera.

<a name='P-EdunovaAPP-Models-Smjer-Vaucer'></a>
### Vaucer `property`

##### Summary

Označava da li smjer ima vaučer.

<a name='T-EdunovaAPP-Controllers-SmjerController'></a>
## SmjerController `type`

##### Namespace

EdunovaAPP.Controllers

##### Summary

Kontroler za upravljanje smjerovima u aplikaciji.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [T:EdunovaAPP.Controllers.SmjerController](#T-T-EdunovaAPP-Controllers-SmjerController 'T:EdunovaAPP.Controllers.SmjerController') | Instanca EdunovaContext klase koja se koristi za pristup bazi podataka. |

<a name='M-EdunovaAPP-Controllers-SmjerController-#ctor-EdunovaAPP-Data-EdunovaContext,AutoMapper-IMapper-'></a>
### #ctor(context,mapper) `constructor`

##### Summary

Kontroler za upravljanje smjerovima u aplikaciji.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [EdunovaAPP.Data.EdunovaContext](#T-EdunovaAPP-Data-EdunovaContext 'EdunovaAPP.Data.EdunovaContext') | Instanca EdunovaContext klase koja se koristi za pristup bazi podataka. |
| mapper | [AutoMapper.IMapper](#T-AutoMapper-IMapper 'AutoMapper.IMapper') | Instanca IMapper sučelja koja se koristi za mapiranje objekata. |

<a name='M-EdunovaAPP-Controllers-SmjerController-Delete-System-Int32-'></a>
### Delete(sifra) `method`

##### Summary

Briše smjer prema šifri.

##### Returns

Status brisanja.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra smjera. |

<a name='M-EdunovaAPP-Controllers-SmjerController-Get'></a>
### Get() `method`

##### Summary

Dohvaća sve smjerove.

##### Returns

Lista DTO objekata smjerova.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Controllers-SmjerController-GetBySifra-System-Int32-'></a>
### GetBySifra(sifra) `method`

##### Summary

Dohvaća smjer prema šifri.

##### Returns

DTO objekt smjera.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra smjera. |

<a name='M-EdunovaAPP-Controllers-SmjerController-Post-EdunovaAPP-Models-DTO-SmjerDTOInsertUpdate-'></a>
### Post(dto) `method`

##### Summary

Dodaje novi smjer.

##### Returns

Status kreiranja i DTO objekt novog smjera.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dto | [EdunovaAPP.Models.DTO.SmjerDTOInsertUpdate](#T-EdunovaAPP-Models-DTO-SmjerDTOInsertUpdate 'EdunovaAPP.Models.DTO.SmjerDTOInsertUpdate') | DTO objekt za unos ili ažuriranje smjera. |

<a name='M-EdunovaAPP-Controllers-SmjerController-Put-System-Int32,EdunovaAPP-Models-DTO-SmjerDTOInsertUpdate-'></a>
### Put(sifra,dto) `method`

##### Summary

Ažurira postojeći smjer prema šifri.

##### Returns

Status ažuriranja.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra smjera. |
| dto | [EdunovaAPP.Models.DTO.SmjerDTOInsertUpdate](#T-EdunovaAPP-Models-DTO-SmjerDTOInsertUpdate 'EdunovaAPP.Models.DTO.SmjerDTOInsertUpdate') | DTO objekt za unos ili ažuriranje smjera. |

<a name='T-EdunovaAPP-Tests-Controllers-SmjerControllerTests'></a>
## SmjerControllerTests `type`

##### Namespace

EdunovaAPP.Tests.Controllers

##### Summary

Test klasa za kontroler SmjerController. Sadrži jedinicne testove za provjeru ispravnosti rada metoda.

<a name='M-EdunovaAPP-Tests-Controllers-SmjerControllerTests-#ctor'></a>
### #ctor() `constructor`

##### Summary

Inicijalizira instancu testa konfigurirajući in memory bazu, mapper i instancu kontrolera.

##### Parameters

This constructor has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-SmjerControllerTests-Delete_ExistingSmjer_ReturnsOkWithSuccessMessage'></a>
### Delete_ExistingSmjer_ReturnsOkWithSuccessMessage() `method`

##### Summary

Testira metodu Delete za brisanje postojećeg smjera i provjerava vraća li status OK s porukom uspjeha.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-SmjerControllerTests-Delete_NonExistingSmjer_ReturnsNotFound'></a>
### Delete_NonExistingSmjer_ReturnsNotFound() `method`

##### Summary

Testira metodu Delete za brisanje nepostojećeg smjera i očekuje rezultat NotFound.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-SmjerControllerTests-GetBySifra_ExistingSmjer_ReturnsOkWithSmjer'></a>
### GetBySifra_ExistingSmjer_ReturnsOkWithSmjer() `method`

##### Summary

Testira metodu GetBySifra za postojeći smjer i provjerava vraća li ispravan DTO.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-SmjerControllerTests-GetBySifra_NonExistingSmjer_ReturnsNotFound'></a>
### GetBySifra_NonExistingSmjer_ReturnsNotFound() `method`

##### Summary

Testira metodu GetBySifra za nepostojeći smjer i očekuje rezultat NotFound.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-SmjerControllerTests-Get_ReturnsOkWithSmjerList'></a>
### Get_ReturnsOkWithSmjerList() `method`

##### Summary

Testira metodu Get i provjerava vraća li ispravan rezultat s listom smjerova.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-SmjerControllerTests-Post_ValidSmjer_ReturnsCreatedWithSmjer'></a>
### Post_ValidSmjer_ReturnsCreatedWithSmjer() `method`

##### Summary

Testira metodu Post za dodavanje novog smjera i provjerava vraća li status Created i ispravan DTO.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-SmjerControllerTests-Put_ExistingSmjer_ReturnsOkWithSuccessMessage'></a>
### Put_ExistingSmjer_ReturnsOkWithSuccessMessage() `method`

##### Summary

Testira metodu Put za ažuriranje postojećeg smjera i provjerava vraća li status OK s porukom uspjeha.

##### Parameters

This method has no parameters.

<a name='M-EdunovaAPP-Tests-Controllers-SmjerControllerTests-Put_NonExistingSmjer_ReturnsNotFound'></a>
### Put_NonExistingSmjer_ReturnsNotFound() `method`

##### Summary

Testira metodu Put za ažuriranje nepostojećeg smjera i očekuje rezultat NotFound.

##### Parameters

This method has no parameters.

<a name='T-EdunovaAPP-Models-DTO-SmjerDTOInsertUpdate'></a>
## SmjerDTOInsertUpdate `type`

##### Namespace

EdunovaAPP.Models.DTO

##### Summary

DTO za unos i ažuriranje smjera.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Naziv | [T:EdunovaAPP.Models.DTO.SmjerDTOInsertUpdate](#T-T-EdunovaAPP-Models-DTO-SmjerDTOInsertUpdate 'T:EdunovaAPP.Models.DTO.SmjerDTOInsertUpdate') | Naziv smjera (obavezno) |

<a name='M-EdunovaAPP-Models-DTO-SmjerDTOInsertUpdate-#ctor-System-String,System-Nullable{System-Decimal},System-Nullable{System-DateTime},System-Nullable{System-Boolean}-'></a>
### #ctor(Naziv,Cijena,IzvodiSeOd,Vaucer) `constructor`

##### Summary

DTO za unos i ažuriranje smjera.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Naziv | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Naziv smjera (obavezno) |
| Cijena | [System.Nullable{System.Decimal}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Decimal}') | Cijena smjera (mora biti između 0 i 10000) |
| IzvodiSeOd | [System.Nullable{System.DateTime}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.DateTime}') | Datum od kada se smjer izvodi |
| Vaucer | [System.Nullable{System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Boolean}') | Indikator da li smjer ima vaučer |

<a name='P-EdunovaAPP-Models-DTO-SmjerDTOInsertUpdate-Cijena'></a>
### Cijena `property`

##### Summary

Cijena smjera (mora biti između 0 i 10000)

<a name='P-EdunovaAPP-Models-DTO-SmjerDTOInsertUpdate-IzvodiSeOd'></a>
### IzvodiSeOd `property`

##### Summary

Datum od kada se smjer izvodi

<a name='P-EdunovaAPP-Models-DTO-SmjerDTOInsertUpdate-Naziv'></a>
### Naziv `property`

##### Summary

Naziv smjera (obavezno)

<a name='P-EdunovaAPP-Models-DTO-SmjerDTOInsertUpdate-Vaucer'></a>
### Vaucer `property`

##### Summary

Indikator da li smjer ima vaučer

<a name='T-EdunovaAPP-Models-DTO-SmjerDTORead'></a>
## SmjerDTORead `type`

##### Namespace

EdunovaAPP.Models.DTO

##### Summary

DTO za čitanje podataka o smjeru.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Sifra | [T:EdunovaAPP.Models.DTO.SmjerDTORead](#T-T-EdunovaAPP-Models-DTO-SmjerDTORead 'T:EdunovaAPP.Models.DTO.SmjerDTORead') | Jedinstvena šifra smjera. |

<a name='M-EdunovaAPP-Models-DTO-SmjerDTORead-#ctor-System-Int32,System-String,System-Nullable{System-Decimal},System-Nullable{System-DateTime},System-Nullable{System-Boolean}-'></a>
### #ctor(Sifra,Naziv,Cijena,IzvodiSeOd,Vaucer) `constructor`

##### Summary

DTO za čitanje podataka o smjeru.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Jedinstvena šifra smjera. |
| Naziv | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Naziv smjera. |
| Cijena | [System.Nullable{System.Decimal}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Decimal}') | Cijena smjera. |
| IzvodiSeOd | [System.Nullable{System.DateTime}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.DateTime}') | Datum od kada se smjer izvodi. |
| Vaucer | [System.Nullable{System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Boolean}') | Indikator da li smjer uključuje vaučer. |

<a name='P-EdunovaAPP-Models-DTO-SmjerDTORead-Cijena'></a>
### Cijena `property`

##### Summary

Cijena smjera.

<a name='P-EdunovaAPP-Models-DTO-SmjerDTORead-IzvodiSeOd'></a>
### IzvodiSeOd `property`

##### Summary

Datum od kada se smjer izvodi.

<a name='P-EdunovaAPP-Models-DTO-SmjerDTORead-Naziv'></a>
### Naziv `property`

##### Summary

Naziv smjera.

<a name='P-EdunovaAPP-Models-DTO-SmjerDTORead-Sifra'></a>
### Sifra `property`

##### Summary

Jedinstvena šifra smjera.

<a name='P-EdunovaAPP-Models-DTO-SmjerDTORead-Vaucer'></a>
### Vaucer `property`

##### Summary

Indikator da li smjer uključuje vaučer.
