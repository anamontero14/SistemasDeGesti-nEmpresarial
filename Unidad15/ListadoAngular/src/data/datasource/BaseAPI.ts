import { Persona } from '../../domain/entities/Persona';
import { injectable } from 'inversify';

@injectable()
export class BaseAPI {
  private readonly API_URL: string = "https://montero-hzedh8ahesg5cceh.francecentral-01.azurewebsites.net/API/";

  async fetchPersonaList(): Promise<Persona[]> {
    let resultado: Persona[] = [];

    try {
      const response = await fetch(`${this.API_URL}/Persona/`);
      const data = await response.json();
      resultado = this.mapearPersonas(data);
    } catch (error) {
      console.error("Error al obtener persona:", error);
      resultado = [];
    }

    return resultado;
  }

  private mapearPersonas(data: any[]): Persona[] {
  return data.map((item) => {
    const fecha = item.fechaNacimiento
      ? new Date(item.fechaNacimiento)
      : null;

      return new Persona(
        item.id,
        item.nombre,
        item.apellidos,
        item.telefono,
        item.idDepartamento,
        item.direccion,
        item.foto,
        fecha
      );
    });
  }
}