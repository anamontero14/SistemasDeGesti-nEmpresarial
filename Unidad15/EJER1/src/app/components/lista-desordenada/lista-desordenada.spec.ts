import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaDesordenada } from './lista-desordenada';

describe('ListaDesordenada', () => {
  let component: ListaDesordenada;
  let fixture: ComponentFixture<ListaDesordenada>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListaDesordenada]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListaDesordenada);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
