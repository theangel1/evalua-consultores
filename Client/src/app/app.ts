import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { PhoneFormatPipe } from './phone-format-pipe';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, PhoneFormatPipe, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {

  private http = inject(HttpClient);
  protected clients= signal<any>([]);
  protected title = "Evalua Consultores"

  ngOnInit(): void {
    this.http.get("http://localhost:5005/api/client").subscribe({
      next: response => this.clients.set(response),
      error: error => console.log(error),
      complete: () => console.log("completed")
    })
  }

  loadClients(){


  }

}
