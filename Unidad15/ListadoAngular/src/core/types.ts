// src/core/types.ts

export const TYPES = {
  // DataSources
  BaseAPI: Symbol.for("BaseAPI"),

  // Repositories
  IRepositoryPersonas: Symbol.for("IRepositoryPersonas"),

  // UseCases
  IUseCasePersonas: Symbol.for("IUseCasePersonas"),

  // ViewModels
  PeopleListVM: Symbol.for("PeopleListVM"),
};