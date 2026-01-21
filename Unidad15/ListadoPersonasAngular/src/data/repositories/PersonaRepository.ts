import { Injectable } from '@angular/core';
import { Persona } from "../../domain/entities/Persona";
import { IRepositoryPersonas } from "../../domain/interfaces/repositories/IRepositoryPersonas";

@Injectable({
  providedIn: 'root'
})
export class PersonasRepository implements IRepositoryPersonas {

    private personas: Persona[] = [
        new Persona(1, 'Fernando', 'Galiana Fernández', 32, new Date(1992, 4, 12), 'Calle Mayor 12', '600123123', 1, 'fernando.jpg'),
        new Persona(2, 'Carlos', 'Martínez López', 28, new Date(1996, 1, 3), 'Av. Libertad 45', '600234234', 2, 'carlos.jpg'),
        new Persona(3, 'Ana', 'Rodríguez Pérez', 30, new Date(1994, 7, 20), 'Calle Sol 88', '600345345', 1, 'ana.jpg'),
        new Persona(4, 'Miguel', 'Sánchez Ruiz', 35, new Date(1989, 10, 5), 'Calle Luna 7', '600456456', 3, 'miguel.jpg'),
        new Persona(5, 'Laura', 'Torres Díaz', 27, new Date(1997, 2, 17), 'Paseo del Río 15', '600567567', 2, 'laura.jpg'),
        new Persona(6, 'David', 'Moreno García', 33, new Date(1991, 8, 30), 'Camino Verde 33', '600678678', 3, 'david.jpg'),
    ];

    getListadoCompletoPersonas(): Persona[] {
        return this.personas;
    }

    getPersonaPorId(id: number): Persona | undefined {
        return this.personas.find(p => p.id === id);
    }

    agregarPersona(persona: Persona): void {
        this.personas.push(persona);
    }

    actualizarPersona(id: number, persona: Persona): boolean {
        const index = this.personas.findIndex(p => p.id === id);
        if (index !== -1) {
            this.personas[index] = persona;
            return true;
        }
        return false;
    }

    eliminarPersona(id: number): boolean {
        const index = this.personas.findIndex(p => p.id === id);
        if (index !== -1) {
            this.personas.splice(index, 1);
            return true;
        }
        return false;
    }
}