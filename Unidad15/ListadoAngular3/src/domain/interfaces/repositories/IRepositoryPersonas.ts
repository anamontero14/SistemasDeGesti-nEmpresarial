import { Persona } from "../../entities/Persona";

/**
 * Interfaz para el repositorio de personas
 * Define los métodos que cualquier implementación debe ofrecer
 */
export interface IRepositoryPersonas {
    //obtiene un listados de todas las personas
    getAllPersonas(): Promise<Persona[]>;
}
