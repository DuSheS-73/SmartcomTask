var path = require('path')
var webpack = require('webpack')
var fs = require('fs')
const VueLoaderPlugin = require('vue-loader/lib/plugin')

module.exports = {
    context: __dirname,
    entry: {
        account: './Scripts/Account/index.js',
        home: './Scripts/Home/index.js',
        items: './Scripts/Items/index.js',
        customers: './Scripts/Customers/index.js'
    },
    output: {
        path: path.resolve(__dirname, './wwwroot/js'),
        filename: '[name].js',
        publicPath: '/'
    },
    resolve: {
        extensions: ['.js', '.vue', '.json'],
        alias: {
            'vue$': 'vue/dist/vue.js',
        }
    },
    module: {
        rules: [
            {
                test: /\.vue$/,
                loader: 'vue-loader',
                options: {
                    loaders: {
                        scss: 'vue-style-loader!css-loader!sass-loader', // <style lang="scss">
                        sass: 'vue-style-loader!css-loader!sass-loader?indentedSyntax' // <style lang="sass">
                    }
                }
            },
            {
                test: /\.js$/,
                loader: 'babel-loader',
                exclude: /node_modules/,
                options: {
                    presets: ['babel-preset-env', 'babel-preset-stage-0'],
                    plugins: ['transform-vue-jsx', 'transform-runtime', 'syntax-dynamic-import']
                }
            },
            {
                test: /\.html$/,
                loader: 'file-loader?name=[name].[ext]',
            },
            {
                test: /\.scss$/,
                loader: 'style-loader!css-loader!sass-loader'
            },
            {
                test: /\.css$/,
                loader: 'style-loader!css-loader'
            },
            {
                test: /\.(eot|svg|ttf|woff|woff2)(\?\S*)?$/,
                loader: 'file-loader'
            },
            {
                test: /\.(png|jpe?g|gif|svg)(\?\S*)?$/,
                loader: 'file-loader',
                query: {
                    name: '[name].[ext]?[hash]'
                }
            }
        ]
    },
    plugins: [
        new webpack.NamedModulesPlugin(),
        new VueLoaderPlugin()
    ]
}