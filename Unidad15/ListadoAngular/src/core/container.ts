// src/core/container.ts
import { Container } from "inversify";
import { TYPES } from "./types";

// DataSource
import { BaseAPI } from "../data/datasource/BaseAPI";

// Repositories
import { PersonasRepository } from "../data/repositories/PersonaRepository";
import { IRepositoryPersonas } from "../domain/interfaces/repositories/IRepositoryPersonas";

// UseCases
import { PersonaUseCase } from "../domain/usecases/UseCasePersona";
import { IUseCasePersonas } from "../domain/interfaces/usecases/IUseCasePersonas";
// ViewModels
import { PeopleListVM } from "../presentation/viewmodels/PeopleListVM";

const container = new Container();

// Bind DataSources
container.bind<BaseAPI>(TYPES.BaseAPI).to(BaseAPI).inSingletonScope();

// Bind Repositories
container.bind<IRepositoryPersonas>(TYPES.IRepositoryPersonas).to(PersonasRepository);

// Bind UseCases
container.bind<IUseCasePersonas>(TYPES.IUseCasePersonas).to(PersonaUseCase);

// Bind ViewModels
container.bind<PeopleListVM>(TYPES.PeopleListVM).to(PeopleListVM).inSingletonScope();

export { container };