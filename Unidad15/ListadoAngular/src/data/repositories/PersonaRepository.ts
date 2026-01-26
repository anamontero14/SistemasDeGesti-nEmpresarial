import { IRepositoryPersonas } from "../../domain/interfaces/repositories/IRepositoryPersonas";
import { Persona } from "../../domain/entities/Persona";
import { BaseAPI } from "../datasource/BaseAPI";
import { inject, injectable } from 'inversify';
import { TYPES } from "../../core/types";

@injectable()
export class PersonasRepository implements IRepositoryPersonas {
  private readonly _dataSource: BaseAPI;

  constructor(@inject(TYPES.BaseAPI) dataSource: BaseAPI) {
    this._dataSource = dataSource;
  }

  async getAllPersonas(): Promise<Persona[]> {
    const resultado = await this._dataSource.fetchPersonaList();
    return resultado;
  }

}
