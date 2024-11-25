import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-data-binding',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './data-binding.component.html',
  styleUrl: './data-binding.component.css'
})
export class DataBindingComponent {
  name = 'John Doe';
  isActive = true;
  currentDate = new Date();
  inputValue = '';

  save(){
    console.log("Data saved:", this.inputValue);
  }

  changeName(){
    this.name = "Jane Doe";
  }
}
