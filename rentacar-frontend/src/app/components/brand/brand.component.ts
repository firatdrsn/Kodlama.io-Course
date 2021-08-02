import { Component, OnInit } from '@angular/core';
import { Brand } from 'src/app/models/brand';
import { BrandService } from 'src/app/services/brand.service';

@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrls: ['./brand.component.css']
})
export class BrandComponent implements OnInit {
  brands: Brand[] = [];
  currentBrand: Brand;
  allCarsList: boolean = true;

  constructor(private brandService: BrandService) { }

  ngOnInit(): void {
    this.getBrands();
  }

  getBrands() {
    this.brandService.getBrands().subscribe(response => {
      this.brands = response.data;
    })
  }

  setCurrentBrand(brand: Brand) {
    this.currentBrand = brand;
    this.allCarsList=false;
    console.log(this.currentBrand);
  }

  getCurrentBrandClass(brand: Brand) {
    if (brand == this.currentBrand && !this.allCarsList) {
      return "list-group-item active"
    } else {
      return "list-group-item"
    }
  }
  public getCurrentBrand() {
    return this.currentBrand;
  }

  allCarsListClick(){
    this.allCarsList=true;
  }

  getAllCarsClass() {
    if (this.allCarsList) {
      return "list-group-item active"
    } else {
      return "list-group-item"
    }
  }
}
