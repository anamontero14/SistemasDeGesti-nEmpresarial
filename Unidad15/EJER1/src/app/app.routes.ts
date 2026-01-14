import { Routes } from '@angular/router';
import { FormularioPersona } from './components/formulario-persona/formulario-persona';
import { ListaDesordenada } from './components/lista-desordenada/lista-desordenada';

export const routes: Routes = [
    {path: 'formulario', component: FormularioPersona},
    {path: 'listado', component: ListaDesordenada}
];
