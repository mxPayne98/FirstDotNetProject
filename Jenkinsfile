#!groovy
pipeline {
    agent {
        docker {
            image 'nosinovacao/dotnet-sonar:20.07.0'
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
                dotnet test //p:CollectCoverage=true //p:CoverletOutputFormat=opencover
                """
            }
        }
        stage('Sonar') {
            steps {
                sh """
                #!/bin/bash
                cd FirstCoreProject
                dotnet build-server shutdown
                dotnet sonarscanner begin /k:"FirstCoreProject" /d:sonar.host.url=http://localhost:9000 /d:sonar.cs.opencover.reportsPaths="coverage.opencover.xml" /d:sonar.coverage.exclusions="Test1.cs"
                dotnet build
                dotnet sonarscanner end
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