import { Persona } from "../../entities/Persona";

/**
 * Interfaz para el repositorio de personas
 * Define los métodos que cualquier implementación debe ofrecer
 */
export interface IUseCasePersonas {
    //obtiene un listado de todas las personas
    getAllPersonas(): Promise<Persona[]>;
}
