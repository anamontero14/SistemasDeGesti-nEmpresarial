import { Injectable } from '@angular/core';
import { makeAutoObservable } from "mobx";
import { Persona } from "../../domain/entities/Persona";
import { UseCasePersonas } from "../../domain/usecases/UseCasePersona";

@Injectable({
  providedIn: 'root'
})
export class PeopleListVM {
    private _personasList: Persona[] = [];
    private _personaSeleccionada: Persona;
   
    constructor(private useCasePersonas: UseCasePersonas) {
        this._personaSeleccionada = new Persona(0, 'Fernando', 'Galiana', 0, new Date(), '', '', 0, '');
        this._personasList = this.useCasePersonas.getListadoCompletoPersonas();
        makeAutoObservable(this);
    }

    public get personasList(): Persona[] {
        return this._personasList;
    }

    public get personaSeleccionada(): Persona {
        return this._personaSeleccionada;
    }

    public set personaSeleccionada(value: Persona) {
        this._personaSeleccionada = value;
    }
}