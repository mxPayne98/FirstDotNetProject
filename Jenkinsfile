#!groovy
pipeline {
    agent {
        docker {
            image 'mcr.microsoft.com/dotnet/core/sdk:3.1'
        }
    }
    environment {
        HOME = '/tmp'
    } 
    stages {
        stage('Preparation') {
            steps {
                checkout scm
            }
        }
        stage('Build') {
            steps {
                sh """
                #!/bin/bash
                cd FirstCoreProject
                dotnet build
                """
            }
        }
        stage('Test') {
            steps {
                sh """
                #!/bin/bash
                cd FirstCoreProject
                dotnet build
                """
            }
        }
        stage('Run') {
            steps {
                sh """
                #!/bin/bash
                cd FirstCoreProject
                dotnet run
                """
            }
        }
    }
}