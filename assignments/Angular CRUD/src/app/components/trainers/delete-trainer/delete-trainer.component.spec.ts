import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteTrainerComponent } from './delete-trainer.component';

describe('DeleteTrainerComponent', () => {
  let component: DeleteTrainerComponent;
  let fixture: ComponentFixture<DeleteTrainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteTrainerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteTrainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
