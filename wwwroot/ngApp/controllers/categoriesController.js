class CategoriesController {
    constructor($categoryService) {
        this.categories = $categoryService.getCategories();
        
    }
    
    categoryDetails(id){
        this.state.go("category", {id: id});
    }
}