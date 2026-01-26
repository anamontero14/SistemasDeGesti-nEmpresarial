// src/presenter/viewmodels/PersonaVM.ts

import { injectable, inject } from "inversify";
import { makeAutoObservable, runInAction } from "mobx";
import { IUseCasePersonas } from "@/src/domain/interfaces/usecases/IUseCasePersonas";
import { Persona } from "../../domain/entities/Persona";
import { TYPES } from "../../core/types";

@injectable()
export class PeopleListVM {
  private _personasList: Persona[] = [];
  private _personaSeleccionada: Persona | null = null;
  private _isLoading: boolean = false;
  private readonly _casoDeUsoPersona: IUseCasePersonas;

  constructor(@inject(TYPES.IUseCasePersonas) casoDeUsoPersona: IUseCasePersonas) {
    this._casoDeUsoPersona = casoDeUsoPersona;
    makeAutoObservable(this);
  }

  //devuelve una lista de personas
  get PersonaList(): Persona[] {
    return this._personasList;
  }

  //devuelve la persona seleccionada
  get PersonaSeleccionada(): Persona | null {
    return this._personaSeleccionada;
  }

  //actualiza la persona seleccionada EN LA VARIABLE DEL VIEW MODEL
  set PersonaSeleccionada(persona: Persona | null) {
    this._personaSeleccionada = persona;
  }

  //variable para controlar que los datos se están cargando
  get isLoading(): boolean {
    return this._isLoading;
  }

  //función que carga personas de la BBDD
  async cargarPersonas(): Promise<void> {
    runInAction(() => {
      //la variable que controla que se estén cargando los datos pasa a ser true
      //(porque está cargando datos)
      this._isLoading = true; 
    })
    //se almacenan la lista de todas las personas obtenidas en la variable
    const personas = await this._casoDeUsoPersona.getAllPersonas();
    
    runInAction(() => {
      //se actualiza la variable de la lista de personas y la de carga de datos
      this._personasList = personas;
      //la carga de datos ha terminado
      this._isLoading = false;
    })
  }
}