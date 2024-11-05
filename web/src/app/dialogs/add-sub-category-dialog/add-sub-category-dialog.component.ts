import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { environment } from '../../../environments/environment';

interface SubCategoryType{
  id: number;
  productName: string;
  categoryName: string;
  subCategoryName: string;
}

@Component({
  selector: 'app-add-sub-category-dialog',
  templateUrl: './add-sub-category-dialog.component.html',
  styleUrl: './add-sub-category-dialog.component.css'
})
export class AddSubCategoryDialogComponent implements OnInit{
  subCategoryTypes: SubCategoryType[] = [];

  subCategoryTypeForm: FormGroup;

  constructor(
    private http: HttpClient,
    private dialogRef: MatDialogRef<AddSubCategoryDialogComponent>,
    private fb: FormBuilder
  ) {
    this.subCategoryTypeForm = this.fb.group({
      subCategoryName: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.loadSubCategoryTypes();
  }

  loadSubCategoryTypes(): void {
    this.http.get<SubCategoryType[]>(`${environment.apiUrl}/Categories/GetSubCategoryType`)
      .subscribe(
        (data) => {
          this.subCategoryTypes = data;
        },
        (error) => {
          console.error('Error loading product types:', error);
        }
      );
  }

  onSave() {
    if (this.subCategoryTypeForm.valid) {
      this.dialogRef.close(this.subCategoryTypeForm.value); // Pass form data to the parent component
    }
  }

  onCancel() {
    this.dialogRef.close();
  }
}
