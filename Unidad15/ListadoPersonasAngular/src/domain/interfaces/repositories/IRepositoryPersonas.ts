import { Persona } from "../../entities/Persona";

/**
 * Interfaz para el repositorio de personas
 * Define los métodos que cualquier implementación debe ofrecer
 */
export interface IRepositoryPersonas {
    /**
     * Devuelve la lista completa de personas
     */
    getListadoCompletoPersonas(): Persona[] | undefined;

    /**
     * Devuelve una persona por su ID
     * @param id Identificador de la persona
     */
    getPersonaPorId(id: number): Persona | undefined;
}
