import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TablaPersonas } from './components/tabla-personas/tabla-personas';
import { ListaDesordenada } from './components/lista-desordenada/lista-desordenada';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TablaPersonas, ListaDesordenada],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('EJER2');
}
