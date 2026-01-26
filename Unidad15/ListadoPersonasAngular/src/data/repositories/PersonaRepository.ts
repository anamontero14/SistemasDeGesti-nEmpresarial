import { Injectable } from '@angular/core';
import { IRepositoryPersonas } from "../../domain/interfaces/repositories/IRepositoryPersonas";
import { Persona } from "../../domain/entities/Persona";
import { BaseAPI } from "../datasource/BaseAPI";

@Injectable({
  providedIn: 'root'
})
export class PersonasRepository implements IRepositoryPersonas {
  private personas: Persona[] = [];

  constructor(private readonly dataSource: BaseAPI) {}

  async cargarPersonas(): Promise<void> {
    this.personas = await this.dataSource.fetchPersonaList();
  }

  getListadoCompletoPersonas(): Persona[] {
    return this.personas;
  }

  getPersonaPorId(id: number): Persona | undefined {
    return this.personas.find(p => p.ID === id);
  }
}