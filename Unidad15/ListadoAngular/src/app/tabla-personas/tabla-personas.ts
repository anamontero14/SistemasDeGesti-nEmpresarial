import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { Persona } from '../../domain/entities/Persona';
import { PeopleListVM } from '../../presentation/viewmodels/PeopleListVM';
import { container } from '../../core/container';
import { TYPES } from '../../core/types';

@Component({
  selector: 'app-tabla-personas',
  imports: [MatTableModule, CommonModule],
  templateUrl: './tabla-personas.html',
  styleUrl: './tabla-personas.css',
})
export class TablaPersonas implements OnInit {
  displayedColumns: string[] = ['id', 'nombre', 'apellidos', 'edad', 'telefono'];
  dataSource: Persona[] = [];
  private viewmodel: PeopleListVM;

  constructor(private cdr: ChangeDetectorRef) {
    this.viewmodel = container.get<PeopleListVM>(TYPES.PeopleListVM);
  }

  async ngOnInit(): Promise<void> {
    await this.cargarPersonas();
  }

  async cargarPersonas(): Promise<void> {
    await this.viewmodel.cargarPersonas();
    this.dataSource = [...this.viewmodel.PersonaList]; // ← Crea una nueva referencia
    console.log('Datos cargados desde la vista', this.dataSource);
    this.cdr.detectChanges(); // ← Fuerza la detección de cambios
  }
}