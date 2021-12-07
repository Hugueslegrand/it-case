import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowDatabaseComponent } from './show-database.component';

describe('ShowDatabaseComponent', () => {
  let component: ShowDatabaseComponent;
  let fixture: ComponentFixture<ShowDatabaseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowDatabaseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowDatabaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
