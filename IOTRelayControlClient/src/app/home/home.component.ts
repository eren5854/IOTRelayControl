import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, OnInit, Renderer2, ViewChild } from '@angular/core';
import { SensorModel } from '../models/sensor.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  @ViewChild('sideMenu') sideMenu: ElementRef| undefined;

  sensors: SensorModel[] = [];
  sensorName = "";

  changeData: number = 0;

  isDarkTheme = true;
  isSideBarOpen = false;
  isInputVisible = false;

  constructor(
    private http: HttpClient,
    private renderer: Renderer2
  ) {
    this.getAllSensors();
  }

  ngOnInit(){
    this.renderer.addClass(document.body, 'dark-theme-variables');
    this.getAllSensors();
  }

  getAllSensors(){
    this.http.get<SensorModel[]>("https://192.168.1.105:45455/api/Sensors/GetAll")
    .subscribe({
      next: (res) => {
        // console.log(res);
        this.sensors = res;
      }
    })
  }

  createSensor(){
    this.http.get<SensorModel>(`https://localhost:7170/api/Sensors/Create?Name=${this.sensorName}&Data=0`)
    .subscribe({
      next: (res:any) => {
        this.getAllSensors();
        this.sensorName = "";
        this.isInputVisible = false;
      }
    })
  }

  updateSensor(sensor: SensorModel){
    if (sensor.data === 0) {
      this.changeData = 1;
    }
    else{
      this.changeData = 0;
    }
    this.http.get<SensorModel>(`https://192.168.1.105:45455/api/Sensors/Update?Id=${sensor.id}&Name=${sensor.name}&Data=${this.changeData}`)
    .subscribe({
      next: (res:any) => {
        this.getAllSensors();
      }
    })
  }

  deleteSensorById(id:any){
    this.http.get(`https://localhost:7170/api/Sensors/DeleteById/${id}`)
    .subscribe({
      next: (res:any) => {
        this.getAllSensors();
      }
    })
  }

  toggleTheme(): void {
    this.isDarkTheme = !this.isDarkTheme;
    if (this.isDarkTheme) {
      this.renderer.addClass(document.body, 'dark-theme-variables');
    } else {
      this.renderer.removeClass(document.body, 'dark-theme-variables');
    }
  }

  toggleSideBar(): void {
    this.isSideBarOpen = !this.isSideBarOpen;
    const sideMenuElement = this.sideMenu?.nativeElement as HTMLElement;

    if (this.isSideBarOpen) {
      sideMenuElement.style.display = 'block';
    } else {
      sideMenuElement.style.display = 'none';
    }
  }

  currentDate: string = "";
  getDate(){
    const today = new Date();
    const yyyy = today.getFullYear();
    const mm = String(today.getMonth() + 1).padStart(2, '0'); // Months are zero based
    const dd = String(today.getDate()).padStart(2, '0');
    this.currentDate = `${yyyy}-${mm}-${dd}`;
  }

  editSensor(sensor: any) {
    sensor.isEditing = true;
  }

  saveSensor(sensor: any, event: any) {
    sensor.name = event.target.value;
    sensor.isEditing = false;
    this.updateSensor(sensor);
  }

  cancelUpdate(sensor: any){
    sensor.isEditing = false;
  }

  inputVisible(){
    this.isInputVisible = !this.isInputVisible;
    if (!this.isInputVisible) {
      this.sensorName = ''; 
    }
  }
}
