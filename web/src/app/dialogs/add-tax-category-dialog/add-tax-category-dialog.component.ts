import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-tax-category-dialog',
  templateUrl: './add-tax-category-dialog.component.html',
  styleUrl: './add-tax-category-dialog.component.css'
})
export class AddTaxCategoryDialogComponent {
  taxTypeForm: FormGroup;

  constructor(
    private dialogRef: MatDialogRef<AddTaxCategoryDialogComponent>,
    private fb: FormBuilder
  ) {
    this.taxTypeForm = this.fb.group({
      productName: ['', Validators.required],
    });
  }

  onSave() {
    if (this.taxTypeForm.valid) {
      this.dialogRef.close(this.taxTypeForm.value); // Pass form data to the parent component
    }
  }

  onCancel() {
    this.dialogRef.close();
  }
}
