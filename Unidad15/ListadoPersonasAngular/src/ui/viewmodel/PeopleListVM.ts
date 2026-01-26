import { Injectable } from '@angular/core';
import { makeAutoObservable } from "mobx";
import { Persona } from "../../domain/entities/Persona";
import { UseCasePersonas } from '../../domain/usecases/UseCasePersona';

@Injectable({
  providedIn: 'root'
})
export class PeopleListVM {
    private _personasList: Persona[] = [];
    private _personaSeleccionada: Persona | undefined;

    constructor(private useCasePersonas: UseCasePersonas) {
        this._personasList = this.useCasePersonas.getListadoCompletoPersonas();
        makeAutoObservable(this);
    }

    public get personasList(): Persona[] {
        return this._personasList;
    }

    public get personaSeleccionada(): Persona | undefined {
        return this._personaSeleccionada;
    }

    public seleccionarPersona(idPersona: number): void {
        this._personaSeleccionada = this.useCasePersonas.getPersonaSeleccionada(idPersona);
    }
}