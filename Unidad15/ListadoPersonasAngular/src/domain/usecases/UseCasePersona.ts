import { Injectable } from '@angular/core';
import { Persona } from "../entities/Persona";
import { IUseCasePersonas } from "../interfaces/usecases/IUseCasePersonas";
import { PersonasRepository } from "../../data/repositories/PersonaRepository";

@Injectable({
  providedIn: 'root'
})
export class UseCasePersonas implements IUseCasePersonas {

    constructor(private repositoryPersonas: PersonasRepository) { }

    getListadoCompletoPersonas(): Persona[] {
        return this.repositoryPersonas.getListadoCompletoPersonas();
    }
}