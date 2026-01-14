import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-links',
  imports: [RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './links.html',
  styleUrl: './links.css',
})
export class Links {

}
