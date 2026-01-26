// src/domain/usecases/PersonaUseCase.ts

import { injectable, inject } from "inversify";
import { IUseCasePersonas } from "../interfaces/usecases/IUseCasePersonas";
import { IRepositoryPersonas } from "../interfaces/repositories/IRepositoryPersonas";
import { Persona } from "../entities/Persona";
import { TYPES } from "../../core/types";

@injectable()
export class PersonaUseCase implements IUseCasePersonas {
  private readonly _personaRepository: IRepositoryPersonas;

  constructor(
    @inject(TYPES.IRepositoryPersonas) personaRepository: IRepositoryPersonas
  ) {
    this._personaRepository = personaRepository;
  }

  async getAllPersonas(): Promise<Persona[]> {
    const todasLasPersonas = await this._personaRepository.getAllPersonas();
    const personasFiltradas = this.aplicarLogicaNegocio(todasLasPersonas);
    return personasFiltradas;
  }

  private aplicarLogicaNegocio(personas: Persona[]): Persona[] {
    const hoy = new Date();
    const diaSemana = hoy.getDay();
    const esViernesOSabado = diaSemana === 5 || diaSemana === 6;
    let resultado: Persona[] = [];

    if (esViernesOSabado) {
      resultado = personas.filter((persona) => {
        if (!persona.FechaNacimiento) {
          //si no tiene fecha, no puede ser mayor de edad
          return false;
        }
          const edad = this.calcularEdad(persona.FechaNacimiento);
          return edad >= 18;
        });
    } else {
      resultado = personas;
    }

    return resultado;
  }

  private calcularEdad(fechaNacimiento: Date): number {
    const hoy = new Date();
    const nacimiento = new Date(fechaNacimiento);
    let edad = hoy.getFullYear() - nacimiento.getFullYear();
    const mes = hoy.getMonth() - nacimiento.getMonth();
    const condicionMes = mes < 0 || (mes === 0 && hoy.getDate() < nacimiento.getDate());

    if (condicionMes) {
      edad = edad - 1;
    }

    return edad;
  }
}