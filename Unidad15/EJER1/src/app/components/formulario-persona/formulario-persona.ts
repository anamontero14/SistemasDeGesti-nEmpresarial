import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';


@Component({
  selector: 'app-formulario-persona',
  imports: [ReactiveFormsModule],
  templateUrl: './formulario-persona.html',
  styleUrl: './formulario-persona.css',
})
export class FormularioPersona implements OnInit {

  formulario!: FormGroup;

  constructor() { 
  }

  ngOnInit(): void {

    this.formulario = new FormGroup(
      {
        nombre: new FormControl('',[Validators.required]),
        apellidos:new FormControl('',[Validators.required])
      }
    );
  }

  saluda(){
    if (this.formulario.valid){
      alert('Hola ' + this.formulario.controls['nombre'].value + ' ' + this.formulario.controls['apellidos'].value);
  } else {
      alert('El formulario no es válido')
  }}
}