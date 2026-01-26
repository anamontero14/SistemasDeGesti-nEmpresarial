import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TablaPersonas } from './tabla-personas/tabla-personas';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TablaPersonas],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('ListadoAngular');
}
