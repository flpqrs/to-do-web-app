import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MissionsColumnComponent } from './missions-column.component';

describe('MissionsColumnComponent', () => {
  let component: MissionsColumnComponent;
  let fixture: ComponentFixture<MissionsColumnComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MissionsColumnComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MissionsColumnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
