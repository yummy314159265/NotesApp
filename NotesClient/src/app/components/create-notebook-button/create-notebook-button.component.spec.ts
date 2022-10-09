import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateNotebookButtonComponent } from './create-notebook-button.component';

describe('CreateNotebookButtonComponent', () => {
  let component: CreateNotebookButtonComponent;
  let fixture: ComponentFixture<CreateNotebookButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateNotebookButtonComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateNotebookButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
