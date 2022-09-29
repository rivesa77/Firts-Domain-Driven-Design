

ESTRUCTURA INICIAL PROYECTO
DOC
SRC
	- API
	- CORE
		- DOMAIN (DEFINICION CLASES)
			
		- APPLICATION
				- Behaviours (Comportamientos)
				
				- Contracts (Contratos)
					- Persistence  (Generamos los interfaces de IAsyncRepository de las clases)
				
				- Features (Caracteristicas)		
					- ENTIDAD 1
						Commands
							- Create
							- Update
							- Delete
						Queries

					- ENTIDAD N
						Commands
						Queries

	- INFRAESTRUCTURE

	
TEST


LIBRERIAS AÑADIDAS A APPLICATION
	- Microsoft.Extensions.Logging.Abstractions
	- MediatR.Extensions.Microsoft.DependencyInjection
	- FluentValidation.DependencyInjectionExtensions
	- FluentValidation
	- AutoMapper.Extensions.Microsoft.DependencyInjection
	- AutoMapper







