import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'new title';
  weatherForecasts: any;

  constructor(private http: HttpClient) {}
  ngOnInit(): void {
    this.http.get('http://localhost:5297/weatherforecast').subscribe(
      (response) => {
        this.weatherForecasts = response;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
