class CategoryController {
    constructor($adService,$stateParams,$categoryService,$state) {
        this.id = $stateParams["id"];
        this.category = $categoryService.getCategory(this.id);
        this.ad = $adService.getAd(this.id);
        this.state = $state;
    }
    
    getImgUrl(images) {

        let result = "";        
        try {
            return images.filter(image => image.isPrimary)[0].url;
        } catch (err) {
            result = "http://phylinx.com/wp-content/uploads/2015/03/FPO-IMAGE.png";
        }

        return result;
    }
    getDetails(id){
        this.state.go("adDetails",{id:id});
    }
}