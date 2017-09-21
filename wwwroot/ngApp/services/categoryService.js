class CategoryService {
    constructor($resource, $stateParams, $cacheFactory) {
        this.categoriesResource = $resource("/api/Categories/:id");
    }

    getCategories() {
        return this.categoriesResource.query();
    }

    getCategory(id) {
        return this.categoriesResource.get({ id: id });
    }

    editCategory(id, category, callback) {
        this.categoriesResource.update({ id: id }, category, callback);
    }

    deleteCategory(id, callback) {
        this.categoriesResource.remove({ id: id }, callback);
    }
}