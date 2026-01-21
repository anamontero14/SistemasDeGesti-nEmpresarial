import { Component, OnInit } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field'; 
import { MatCardModule } from '@angular/material/card'; 
import { MatInputModule } from '@angular/material/input';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-formulario-material',
  imports: [
    MatFormFieldModule, 
    MatCardModule, 
    MatInputModule,
    ReactiveFormsModule,
    CommonModule
  ],
  templateUrl: './formulario-material.html',
  styleUrl: './formulario-material.css',
})
export class FormularioMaterial implements OnInit {
  formulario: FormGroup;

  constructor() {
    this.formulario = new FormGroup({
      nombre: new FormControl('', [Validators.required, Validators.minLength(4)]),
      apellidos: new FormControl('', [Validators.required])
    });
  }

  ngOnInit(): void {
  }
}