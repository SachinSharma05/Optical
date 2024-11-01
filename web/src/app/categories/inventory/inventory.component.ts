import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';

interface ItemType {
  id: number;
  productName: string;
}

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrl: './inventory.component.css'
})
export class InventoryComponent implements OnInit {
  productTypes: ItemType[] = [];
  categoryTypes: string[] = [];
  subCategoriesType: string[] = [];
  taxCategories: string[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadProductTypes();
    this.loadCategoryTypes();
    this.loadSubCategoryTypes();
    this.loadTaxCategories();
  }

  loadProductTypes(): void {
    this.http.get<ItemType[]>(`${environment.apiUrl}/Categories/GetProductType`)
      .subscribe(
        (data) => {
          console.log('Product Types:', data);
          this.productTypes = data;
        },
        (error) => {
          console.error('Error loading product types:', error);
        }
      );
  }

  loadCategoryTypes(): void {
    this.http.get<string[]>(`${environment.apiUrl}/Categories/GetCategoryType`)
      .subscribe(
        (data) => {
          this.categoryTypes = data;
        },
        (error) => {
          console.error('Error loading product types:', error);
        }
      );
  }

  loadSubCategoryTypes(): void {
    this.http.get<string[]>(`${environment.apiUrl}/Categories/GetSubCategoryType`)
      .subscribe(
        (data) => {
          this.subCategoriesType = data;
        },
        (error) => {
          console.error('Error loading product types:', error);
        }
      );
  }

  loadTaxCategories(): void {
    this.http.get<string[]>(`${environment.apiUrl}/Categories/GetTaxCategories`)
      .subscribe(
        (data) => {
          this.taxCategories = data;
        },
        (error) => {
          console.error('Error loading product types:', error);
        }
      );
  }
}
