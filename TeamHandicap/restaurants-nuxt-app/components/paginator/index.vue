<template>
    <ul v-if="pagesWindow && pagesWindow.length" class="pagination">
        <li class="page-item" :class="{ disabled: clampedPageIndex <= 0 }">
            <button type="button" class="page-link" @click="clampedPageIndex > 0 && onPageChanged(0)">First</button>
        </li><li class="page-item d-none d-sm-inline-block" :class="{ disabled: clampedPageIndex <= 0 }">
            <button type="button" class="page-link" @click="clampedPageIndex > 0 && onPageChanged(clampedPageIndex - 1)">Previous</button>
        </li><li v-for="pageItem of pagesWindow" :key="'page' + pageItem" class="page-item" :class="{ active: pageItem === clampedPageIndex }">
            <button type="button" class="page-link" @click="onPageChanged(pageItem)">{{ pageItem + 1 }}</button>
        </li><li class="page-item d-none d-sm-inline-block" :class="{ disabled: clampedPageIndex >= pageCount - 1 }">
            <button type="button" class="page-link" @click="clampedPageIndex < (pageCount - 1) && onPageChanged(clampedPageIndex + 1)">Next</button>
        </li><li class="page-item" :class="{ disabled: clampedPageIndex >= pageCount - 1 }">
            <button type="button" class="page-link" @click="clampedPageIndex < (pageCount - 1) && onPageChanged(pageCount - 1)">Last</button>
        </li>
    </ul>
</template>

<script src="./paginator.js"></script>
<style scoped lang="scss" rel="stylesheet/scss">
@import './paginator.scss';
</style>