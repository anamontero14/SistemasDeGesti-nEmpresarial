import { Component, OnInit } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { Persona } from '../../domain/entities/Persona';
import { UseCasePersonas } from '../../domain/usecases/UseCasePersona';

@Component({
  selector: 'app-tabla-personas',
  imports: [MatTableModule, CommonModule],
  templateUrl: './tabla-personas.html',
  styleUrl: './tabla-personas.css',
})
export class TablaPersonas implements OnInit {
  displayedColumns: string[] = ['id', 'nombre', 'apellidos', 'edad', 'telefono'];
  dataSource: Persona[] = [];

  constructor(private casoDeUso: UseCasePersonas) {}

  async ngOnInit(): Promise<void> {
    await this.cargarPersonas();
  }

  async cargarPersonas(): Promise<void> {
    await this.casoDeUso.getListadoCompletoPersonas();
    this.dataSource = this.casoDeUso.getListadoCompletoPersonas();
    console.log('Datos cargados desde la vista', this.dataSource);
  }
}