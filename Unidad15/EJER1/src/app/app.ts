import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TablaPersonas } from './components/tabla-personas/tabla-personas';
import { Links } from './components/links/links';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TablaPersonas, Links],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('EJER2');
}
