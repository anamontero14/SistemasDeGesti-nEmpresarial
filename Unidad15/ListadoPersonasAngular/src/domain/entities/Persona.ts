// src/domain/entities/Persona.ts

export class Persona {
  private readonly _ID: number;
  private _Nombre: string;
  private _Apellidos: string;
  private _Telefono: string;
  private _Direccion?: string | null;
  private _Foto?: string | null;
  private _FechaNacimiento?: Date | null;
  private _IDDepartamento: number;

  constructor(
    ID: number,
    Nombre: string,
    Apellidos: string,
    Telefono: string,
    IDDepartamento: number,
    Direccion?: string | null,
    Foto?: string | null,
    FechaNacimiento?: Date | null
  ) {
    this._ID = ID;
    this._Nombre = Nombre;
    this._Apellidos = Apellidos;
    this._Telefono = Telefono;
    this._Direccion = Direccion ?? null; 
    this._Foto = Foto ?? null; 
    this._FechaNacimiento = FechaNacimiento ?? null;
    this._IDDepartamento = IDDepartamento;
  }

  get ID(): number {
    return this._ID;
  }

  get Nombre(): string {
    return this._Nombre;
  }

  set Nombre(value: string) {
    this._Nombre = value;
  }

  get Apellidos(): string {
    return this._Apellidos;
  }

  set Apellidos(value: string) {
    this._Apellidos = value;
  }

  get Telefono(): string {
    return this._Telefono;
  }

  set Telefono(value: string) {
    this._Telefono = value;
  }

  get Direccion(): string {
    return this._Direccion ?? "";
  }

  set Direccion(value: string) {
    this._Direccion = value;
  }

  get Foto(): string {
    return this._Foto ?? "";
  }

  set Foto(value: string) {
    this._Foto = value;
  }

  get FechaNacimiento(): Date | null {
    return this._FechaNacimiento ?? null;
  }

  set FechaNacimiento(value: Date) {
    this._FechaNacimiento = value;
  }

  get IDDepartamento(): number {
    return this._IDDepartamento;
  }

  set IDDepartamento(value: number) {
    this._IDDepartamento = value;
  }

  get Edad(): number {
    if (!this._FechaNacimiento) return 0;
    const hoy = new Date();
    let edad = hoy.getFullYear() - this._FechaNacimiento.getFullYear();
    const mes = hoy.getMonth() - this._FechaNacimiento.getMonth();
    if (mes < 0 || (mes === 0 && hoy.getDate() < this._FechaNacimiento.getDate())) {
      edad--;
    }
    return edad;
  }
}