import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowTaComponent } from './show-ta.component';

describe('ShowTaComponent', () => {
  let component: ShowTaComponent;
  let fixture: ComponentFixture<ShowTaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowTaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowTaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
