import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowColComponent } from './show-col.component';

describe('ShowColComponent', () => {
  let component: ShowColComponent;
  let fixture: ComponentFixture<ShowColComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowColComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowColComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
